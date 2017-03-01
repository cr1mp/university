fis = readfis('CopyVoskanyan');
fuzzy(fis);
X = [0; 0.5; 0.9];
Y = [0; 0.55; 1];
M = [0 0 0.3; 0 0.55 0.3; 0 1 0.5;
    0.5 0 0.3; 0.5 0.55 0.5; 0.5 1 0.8;
    0.9 0 0.5;  0.9 0.55 0.8;  0.9 1 0.8];
train = GetTrainSample(1,1,X,Y,M);
test = GetTestSample(1,1,X,Y,M);