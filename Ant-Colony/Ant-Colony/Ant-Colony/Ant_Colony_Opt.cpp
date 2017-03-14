//
//  Ant_Colony_Opt.cpp
//  Ant-Colony
//
//  Created by SMIT DOSHI on 3/14/17.
//  Copyright © 2017 SMIT DOSHI. All rights reserved.
//

#include "Ant_Colony_Opt.hpp"

#include <iostream>
#include <cstdlib>

#include <cmath>
#include <limits>
#include <climits>

using namespace std;

ACO :: ACO(int nAnts, int nCities, double alpha, double beta,
           double q, double ro, double taumax, int initCity){
    numbOFANTS = nAnts;
    numbOFCITIES = nCities;
    Alpha = alpha;
    Beta = beta;
    Q = q;
    RO = ro;
    TAUMAX = taumax;
    initialCITY = initCity;
    
    randoms = new Randoms(21);
}

// Pure Virtual Destructor indicating class ACO will be used as a Base Class.
ACO:: ~ACO(){
    for(int i=0;i<numbOFCITIES;i++){
        delete [] Graph[i];
        delete [] Cities[i];
        delete [] Pheromones[i];
        delete [] DeltaPheromones[i];
        
        if(i < numbOFCITIES -1){
            delete [] Probs[i];
        }
    }
    
    delete [] Graph;
    delete [] Cities;
    delete [] Pheromones;
    delete [] DeltaPheromones;
    delete [] Probs;
    
}

void ACO::init(){
    Graph = new int *[numbOFCITIES];
    Cities = new double*[numbOFCITIES];
    Pheromones = new double*[numbOFCITIES];
    DeltaPheromones = new double*[numbOFCITIES];
    Probs = new double*[numbOFCITIES];
    
    for(int i=0;i<numbOFCITIES;i++){
        Graph[i] = new int[numbOFCITIES];
        Cities[i] = new double[2];
        Pheromones[i] = new double[numbOFCITIES];
        DeltaPheromones[i] = new double[numbOFCITIES];
        Probs[i] = new double[2];
        
        for(int j=0; j<2; j++){
            Cities[i][j] = -1.0;
            Probs[i][j] = -1.0;
        }
        
        for(int j=0; j<numbOFCITIES;j++){
            Graph[i][j] = 0;
            Pheromones[i][j] = 0.0;
            DeltaPheromones[i][j] = 0.0;
        }
    }
    
    Routes = new int*[numbOFANTS];
    for (int i =0; i<numbOFANTS; i++) {
        Routes[i] = new int [numbOFCITIES];
        for (int j=0; i<numbOFCITIES; j++) {
            Routes[i][j] = -1;
        }
    }
    
    BestLength = (double)INT_MAX;
    BestRoute =  new int[numbOFCITIES];
    for(int i=0;i<numbOFCITIES;i++){
        BestRoute[i] = -1;
    }
}

void ACO::connectCITIES(int cityi, int cityj){
    Graph[cityi][cityj] = 1;
    Pheromones[cityi][cityj] = randoms -> Uniforme() * TAUMAX;
    Graph[cityi][cityj] = 1;
    Pheromones[cityi][cityj] = Pheromones[cityi][cityj];
}

void ACO::setCityPosition(int city, double x, double y){
    Cities[city][0] = x;
    Cities[city][1]=y;
}

void ACO::printPheromones(){
    cout << " printPheromones Function called.";  // Testing if function is called or not
    cout<<" Pheromones: " <<endl;
    cout << "  | ";
    for (int i=0; i<numbOFCITIES; i++) {
        printf("%5d   ", i);
    }
    cout << endl << "- | ";
    for (int i=0; i<numbOFCITIES; i++) {
        cout << "--------";
    }
    cout << endl;
    for (int i=0; i<numbOFCITIES; i++) {
        cout << i << " | ";
        for (int j=0; j<numbOFCITIES; j++) {
            if (i == j) {
                printf ("%5s   ", "x");
                continue;
            }
            if (exists(i, j)) {
                printf ("%7.3f ", Pheromones[i][j]);
            }
            else {
                if(Pheromones[i][j] == 0.0) {
                    printf ("%5.0f   ", Pheromones[i][j]);
                }
                else {
                    printf ("%7.3f ", Pheromones[i][j]);
                }
            }
        }
        cout << endl;
    }
    cout << endl;
}

double ACO::distance(int cityi, int cityj){
    return (double)
    sqrt(pow(Cities[cityi][0] - Cities[cityj][0], 2)+
         pow(Cities[cityi][1] - Cities[cityj][1],2));
}

bool ACO::exists(int cityi, int cityc){
    return (Graph[cityi][cityc]==1);
}
bool ACO::visited(int antK, int c){
    for (int l=0; l<numbOFCITIES; l++) {
        if (Routes[antK][l] == -1) {
            break;
        }
        if (Routes[antK][l] == c) {
            return true;
        }
    }
    return false;
}

double ACO::PHI (int cityi, int cityj, int antk) {
    double ETAij = (double) pow (1 / distance (cityi, cityj), Beta);
    double TAUij = (double) pow (Pheromones[cityi][cityj],   Alpha);
    
    double sum = 0.0;
    for (int c=0; c<numbOFCITIES; c++) {
        if (exists(cityi, c)) {
            if (!visited(antk, c)) {
                double ETA = (double) pow (1 / distance (cityi, c), Beta);
                double TAU = (double) pow (Pheromones[cityi][c],   Alpha);
                sum += ETA * TAU;
            }	
        }	
    }
    return (ETAij * TAUij) / sum;
}

double ACO::length (int antk) {
    double sum = 0.0;
    for (int j=0; j<numbOFCITIES-1; j++) {
        sum += distance (Routes[antk][j], Routes[antk][j+1]);
    }
    return sum;
}

int ACO::city () {
    double xi = randoms -> Uniforme();
    int i = 0;
    double sum = Probs[i][0];
    while (sum < xi) {
        i++;
        sum += Probs[i][0];
    }
    return (int) Probs[i][1];
}

void ACO::route (int antk) {
    Routes[antk][0] = initialCITY;
    for (int i=0; i<numbOFCITIES-1; i++) {
        int cityi = Routes[antk][i];
        int count = 0;
        for (int c=0; c<numbOFCITIES; c++) {
            if (cityi == c) {
                continue;
            }
            if (exists (cityi, c)) {
                if (!visited (antk, c)) {
                    Probs[count][0] = PHI (cityi, c, antk);
                    Probs[count][1] = (double) c;
                    count++;
                }
                
            }
        }
        
        // deadlock
        if (0 == count) {
            return;
        }
        
        Routes[antk][i+1] = city();
    }
}

int ACO::valid (int antk, int iteration) {
    for(int i=0; i<numbOFCITIES-1; i++) {
        int cityi = Routes[antk][i];
        int cityj = Routes[antk][i+1];
        if (cityi < 0 || cityj < 0) {
            return -1;
        }
        if (!exists(cityi, cityj)) {
            return -2;
        }
        for (int j=0; j<i-1; j++) {
            if (Routes[antk][i] == Routes[antk][j]) {
                return -3;
            }
        }
    }
    
    if (!exists (initialCITY, Routes[antk][numbOFCITIES-1])) {
        return -4;
    }
    
    return 0;
}


void ACO::printGraph(){
    cout << " GRAPH: " << endl;
    cout << "  | ";
    for( int i=0; i<numbOFCITIES; i++) {
        cout << i << " ";
    }
    cout << endl << "- | ";
    for (int i=0; i<numbOFCITIES; i++) {
        cout << "- ";
    }
    cout << endl;
    int count = 0;
    for (int i=0; i<numbOFCITIES; i++) {
        cout << i << " | ";
        for (int j=0; j<numbOFCITIES; j++) {
            if(i == j) {
                cout << "x ";
            }
            else {
                cout << Graph[i][j] << " ";
            }
            if (Graph[i][j] == 1) {
                count++;	
            }
        }
        cout << endl;
    }
    cout << endl;
    cout << "Number of connections: " << count << endl << endl;
}


void ACO::printResult(){
    BestLength += distance (BestRoute[numbOFCITIES-1], initialCITY);
    cout << " BEST ROUTE:" << endl;
    for (int i=0; i<numbOFCITIES; i++) {
        cout << BestRoute[i] << " ";
    }
    cout << endl << "length: " << BestLength << endl;
    
    cout << endl << " IDEAL ROUTE:" << endl;
    cout << "0 7 6 2 4 5 1 3" << endl;
    cout << "length: 127.509" << endl;
}

void ACO::updatePheromones(){
    for (int k=0; k<numbOFANTS; k++) {
        double rlength = length(k);
        for (int r=0; r<numbOFCITIES-1; r++) {
            int cityi = Routes[k][r];
            int cityj = Routes[k][r+1];
            DeltaPheromones[cityi][cityj] += Q / rlength;
            DeltaPheromones[cityj][cityi] += Q / rlength;
        }
    }
    for (int i=0; i<numbOFCITIES; i++) {
        for (int j=0; j<numbOFCITIES; j++) {
            Pheromones[i][j] = (1 - RO) * Pheromones[i][j] + DeltaPheromones[i][j];
            DeltaPheromones[i][j] = 0.0;
        }	
    }
}

void ACO::optimize (int ITERATIONS) {
    for (int iterations=1; iterations<=ITERATIONS; iterations++) {
        cout << flush;
        cout << "ITERATION " << iterations << " HAS STARTED!" << endl << endl;
        
        for (int k=0; k<numbOFANTS; k++) {
            cout << " : ant " << k << " has been released!" << endl;
            while (0 != valid(k, iterations)) {
                cout << "  :: releasing ant " << k << " again!" << endl;
                for (int i=0; i<numbOFCITIES; i++) {
                    Routes[k][i] = -1;
                }
                route(k);
            }
            
            for (int i=0; i<numbOFCITIES; i++) {
                cout << Routes[k][i] << " ";
            }
            cout << endl;
            
            cout << "  :: route done" << endl;
            double rlength = length(k);
            
            if (rlength < BestLength) {
                BestLength = rlength;
                for (int i=0; i<numbOFCITIES; i++) {
                    BestRoute[i] = Routes[k][i];
                }
            }
            cout << " : ant " << k << " has ended!" << endl;
        }
        
        cout << endl << "updating PHEROMONES . . .";
        updatePheromones();
        cout << " done!" << endl << endl;
        printPheromones();
        
        for (int i=0; i<numbOFANTS; i++) {
            for (int j=0; j<numbOFCITIES; j++) {
                Routes[i][j] = -1;
            }
        }
        
        cout << endl << "ITERATION " << iterations << " HAS ENDED!" << endl << endl;
    }
}
