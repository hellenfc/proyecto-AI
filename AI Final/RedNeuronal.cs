﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Engine.Network.Activation;
using Encog.ML.Data;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Encog.ML.Train;
using Encog.ML.Data.Basic;
using Encog;

namespace AI_Final
{
    
    public class RedNeuronal
    {
       
        double[][] neuralInput = { new [] {0.0,1.0,1.0,0.0,1.0,0.0,0.0,1.0,
                                            0.0,1.0,1.0,1.0,1.0,0.0,1.0,0.0,
                                            0.0,1.0,1.0,1.0,0.0,0.0,0.0,1.0,
                                            0.0,1.0,1.0,1.0,0.0,1.0,0.0,1.0,
                                            0.0,1.0,1.0,0.0,1.0,0.0,0.0,1.0,
                                            0.0,1.0,1.0,0.0,0.0,1.0,0.0,1.0, 
                                            0.0,1.0,1.0,1.0,0.0,0.0,1.0,0.0,
                                            0.0,1.0,1.0,0.0,0.0,1.0,0.0,0.0,
                                            0.0,1.0,1.0,0.0,0.0,0.0,0.0,1.0  },
                new [] {0.0,1.0,1.0,0.0,0.0,1.0,0.0,0.0,
                        0.0,1.0,1.0,0.0,0.0,1.0,0.0,1.0, 
                        0.0,1.0,1.0,1.0,0.0,0.0,1.0,0.0, 
                        0.0,1.0,1.0,0.0,0.0,1.0,0.0,1.0, 
                        0.0,1.0,1.0,0.0,0.0,0.0,1.0,1.0, 
                        0.0,1.0,1.0,0.0,1.0,0.0,0.0,0.0, 
                        0.0,1.0,1.0,0.0,0.0,0.0,0.0,1.0, 
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0, 
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0},
                new [] {0.0,1.0,1.0,0.0,0.0,0.0,0.0,1.0, 
                        0.0,1.0,1.0,1.0,0.0,0.0,1.0,0.0, 
                        0.0,1.0,1.0,1.0,0.0,0.0,1.0,0.0, 
                        0.0,1.0,1.0,0.0,1.0,0.0,0.0,1.0, 
                        0.0,1.0,1.0,0.0,0.0,0.0,1.0,0.0, 
                        0.0,1.0,1.0,0.0,0.0,0.0,0.0,1.0, 
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0, 
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0, 
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0},
                new []{0.0,1.0,1.0,0.0,0.0,0.0,0.0,1.0, 
                        0.0,1.0,1.0,0.0,0.0,0.0,1.0,0.0, 
                        0.0,1.0,1.0,0.0,0.0,0.0,0.0,1.0, 
                        0.0,1.0,1.0,0.0,1.0,0.0,1.0,0.0, 
                        0.0,1.0,1.0,0.0,1.0,1.0,1.0,1.0, 
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0},
                new []{0.0,1.0,1.0,0.0,0.0,0.0,1.0,1.0, 
                        0.0,1.0,1.0,1.0,0.0,1.0,0.0,1.0, 
                        0.0,1.0,1.0,0.0,0.0,0.0,0.0,1.0, 
                        0.0,1.0,1.0,0.0,0.0,1.0,0.0,0.0, 
                        0.0,1.0,1.0,1.0,0.0,0.0,1.0,0.0, 
                        0.0,1.0,1.0,0.0,0.0,0.0,0.0,1.0, 
                        0.0,1.0,1.0,0.0,0.0,1.0,0.0,0.0, 
                        0.0,1.0,1.0,0.0,1.0,1.0,1.0,1.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0},
                new []{0.0,1.0,1.0,0.0,0.0,0.0,1.0,1.0,
                        1.0,0.0,1.0,0.0,0.0,0.0,0.0,1.0, 
                        0.0,1.0,1.0,1.0,0.0,0.0,1.0,0.0, 
                        0.0,1.0,1.0,0.0,0.0,0.0,1.0,1.0, 
                        0.0,1.0,1.0,1.0,0.0,1.0,0.0,1.0, 
                        0.0,1.0,1.0,0.0,1.0,1.0,0.0,0.0, 
                        0.0,1.0,1.0,0.0,1.0,1.0,1.0,1.0, 
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0},
                new []{0.0,1.0,1.0,0.0,0.0,1.0,0.0,1.0, 
                        0.0,1.0,1.0,0.0,1.0,1.0,0.0,0.0, 
                        0.0,1.0,1.0,0.0,1.0,0.0,0.0,1.0, 
                        0.0,1.0,1.0,1.0,0.0,0.0,0.0,0.0, 
                        0.0,1.0,1.0,1.0,0.0,0.0,1.0,1.0, 
                        0.0,1.0,1.0,0.0,0.0,1.0,0.0,1.0, 
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0
                        },
                new []{0.0,1.0,1.0,1.0,0.0,0.0,1.0,0.0,
                        0.0,1.0,1.0,0.0,1.0,1.0,1.0,1.0, 
                        0.0,1.0,1.0,0.0,1.0,0.0,1.0,0.0, 
                        0.0,1.0,1.0,0.0,1.0,1.0,1.0,1.0, 
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0},
                new []{0.0,1.0,1.0,1.0,0.0,1.0,1.0,0.0, 
                        0.0,1.0,1.0,0.0,0.0,1.0,0.0,1.0, 
                        0.0,1.0,1.0,1.0,0.0,0.0,1.0,0.0, 
                        0.0,1.0,1.0,0.0,0.0,1.0,0.0,0.0, 
                        0.0,1.0,1.0,0.0,0.0,1.0,0.0,1.0, 
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0},
                new []{0.0,1.0,1.0,0.0,0.0,0.0,0.0,1.0, 
                        0.0,1.0,1.0,1.0,1.0,0.0,1.0,0.0, 
                        0.0,1.0,1.0,1.0,0.0,1.0,0.0,1.0, 
                        0.0,1.0,1.0,0.0,1.0,1.0,0.0,0.0, 
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0},
                new []{0.0,1.0,1.0,0.0,0.0,0.0,0.0,1.0, 
                        0.0,1.0,1.0,0.0,1.0,1.0,0.0,1.0, 
                        0.0,1.0,1.0,0.0,0.0,0.0,0.0,1.0, 
                        0.0,1.0,1.0,1.0,0.0,0.0,1.0,0.0, 
                        0.0,1.0,1.0,0.0,1.0,0.0,0.0,1.0, 
                        0.0,1.0,1.0,0.0,1.0,1.0,0.0,0.0, 
                        0.0,1.0,1.0,0.0,1.0,1.0,0.0,0.0, 
                        0.0,1.0,1.0,0.0,1.0,1.0,1.0,1.0, 
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0},
                new []{0.0,1.0,1.0,0.0,1.0,1.0,1.0,0.0, 
                        0.0,1.0,1.0,0.0,0.0,1.0,0.0,1.0, 
                        0.0,1.0,1.0,0.0,0.0,1.0,1.0,1.0, 
                        0.0,1.0,1.0,1.0,0.0,0.0,1.0,0.0, 
                        0.0,1.0,1.0,0.0,1.0,1.0,1.0,1.0, 
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,
                        0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0}


                                 };
        double[][] neuralOutput = {
                                  new [] {1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                                  new [] {0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                                  new [] {0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                                  new [] {0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                                  new [] {0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                                  new [] {0.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                                  new [] {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                                  new [] {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0 },
                                  new [] {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0 },
                                  new [] {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0 },
                                  new [] {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0 },
                                  new [] {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1.0 }};
        
        
        IMLDataSet trainingSet;
        BasicNetwork network;
        IMLTrain train;

        public RedNeuronal()
        {
            trainingSet = new BasicMLDataSet(neuralInput, neuralOutput);
            this.network =  new BasicNetwork();            
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, 72));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, 216));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, 144));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, 12));
            network.Structure.FinalizeStructure();
            network.Reset();
            train = new ResilientPropagation(network, trainingSet);
        }

        
        public List<string> entrenar()
        {
            IMLDataSet parsito = new BasicMLDataSet(this.neuralInput, this.neuralOutput);
            List<string> mensajes= new List<string>();
            int epoch = 1;
            do
            {
                train.Iteration();
                mensajes.Add("Ronda # " + epoch + "     -     Porcentaje de Error: " + train.Error);
                epoch++;
            } while ((epoch < 5000 && train.Error > 0.001));
            mensajes.Add("Resultados del Entrenamiento");
            foreach (IMLDataPair pair in parsito)
            {
                IMLData output = network.Compute(pair.Input);
                mensajes.Add("Actuales =" + output[0] + ", " + output[1] + ", " + output[2] + ", " + output[3] + ", " + output[4] + ", " + output[5] + ", " + output[6] + ", " + output[7] + ", " + output[8] + ", " + output[9] + ", " + output[10] + ", " + output[11]
                    + "\n Ideales =" + pair.Ideal[0] + ", " + pair.Ideal[1] + ", " + pair.Ideal[2] + ", " + pair.Ideal[3] + ", " + pair.Ideal[4] + ", " + pair.Ideal[5] + ", " + pair.Ideal[6] + ", " + pair.Ideal[7] + ", " + pair.Ideal[8] + ", " + pair.Ideal[9] + ", " + pair.Ideal[10] + ", " + pair.Ideal[11]);

            }
            return mensajes;
        }

        public List<double> calcularEntrada(double[] entradaNeurona)
        {
            double[][] inputNeural = new double[1][];
            List<double> outputNeuralNetworl = new List<double>();
            inputNeural[0] = entradaNeurona;
            IMLDataSet trainingPairs = new BasicMLDataSet(inputNeural, this.neuralOutput);
            foreach (IMLDataPair pair in trainingPairs) 
            {
                IMLData output = network.Compute(pair.Input);
                for(int i = 0; i < 12; i++)
                {
                    outputNeuralNetworl.Add(output[i]);
                }
            }
            return outputNeuralNetworl;


        }

    }
}