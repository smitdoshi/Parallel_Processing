//
//  Ant_Colony_Opt.hpp
//  Ant-Colony
//
//  Created by SMIT DOSHI on 3/14/17.
//  Copyright © 2017 SMIT DOSHI. All rights reserved.
//

#ifndef Ant_Colony_Opt_hpp
#define Ant_Colony_Opt_hpp

#include <stdio.h>
#include "Random.cpp"

#endif /* Ant_Colony_Opt_hpp */

class ACO{
public:
    
    ACO(int numbAnts, int numbCities, double alpha, double beta, double q, double ro, double taumax, int initCity);
    
    /* Q -> best route
       Ro -> Pheromones Evaporation rate
       Taumax -> Max Pheromone random number
       initCity -> Initial Start City
    */
    
    // Pure Virtual Destructor indicating class ACO will be used as a Base Class.
    virtual ~ACO();
    
    void init();
    // function to show Connection in Cities
    void connectCITIES(int cityI,int cityJ);
    
    // function to set the Values for the Citites
    void setCityPosition(int city, double x, double y);
    
    // Function to just print the Pheromones Traces
    void printPheromones();
    
    //function to print the data in a tabular form
    void printGraph();
    
    // function to print the results at the end of iteration
    void printResult();
    
    void optimize(int Iterations);
    
private:
    double distance(int cityI,int cityJ);
    bool exists (int cityI, int cityC);
    bool visited (int antK, int c);
    double PHI(int cityI, int cityJ, int antK);
    
    double length(int antK);
    
    int city();
    void route(int antK);
    int valid(int antK, int iteration);
    
    void updatePheromones();
    
    int numbOFANTS, numbOFCITIES, initialCITY;
    double Alpha, Beta, Q, RO, TAUMAX;
    
    double BestLength;
    int *BestRoute;
    
    int **Graph, **Routes;
    double **Cities, **Pheromones, **DeltaPheromones, **Probs;
    
    Random *randoms;
    
};
