function [ SampleData ] = GetSampleDataForHighFis(lowFis,in1LowFisMax,in2LowFisMax, in2HighMax,X,Y,M )

in1LowArr = rand(100,1) * in1LowFisMax;
in2LowArr = rand(100,1)* in2LowFisMax;

lowFisOut = evalfis([in1LowArr,in2LowArr],lowFis);

In1 = lowFisOut;
In2 = rand(100,1) * in2HighMax;

resultArr = GetResultData(X,Y,M,In1,In2);

SampleData = [In1, In2, resultArr];

end

