function [ TrainSample ] = GetTrainSample(xMax, yMax,X,Y,M )

TrainX=rand(100,1)* xMax;
TrainY=rand(100,1)* yMax;
Train=zeros(100,1);

for i=1:100 
    Train(i,1)=GetPoint( X, Y, M, TrainX(i,1), TrainY(i,1)); 
end

TrainSample = [TrainX, TrainY, Train];

end

