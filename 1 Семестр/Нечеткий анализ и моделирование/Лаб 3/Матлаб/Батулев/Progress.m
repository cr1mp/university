batulevFis = readfis('BatulevFis');
fuzzy(batulevFis);

M = [0 0 25; 0 50 25; 0 100 5;
    12 0 5; 12 50 15;12 100 5;
    24 0 5;  24 50 25;  24 100 5];

xMax = 24;
yMax = 100;

X = [0;12;24];
Y = [0;50;100];

test = GetSampleData(xMax,yMax,X,Y,M);
train = GetSampleData(xMax,yMax,X,Y,M);