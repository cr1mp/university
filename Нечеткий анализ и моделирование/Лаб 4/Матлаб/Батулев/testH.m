st1 = zeros(125,1);
st2 = zeros(125,1);
st3 = zeros(125,1);

in1Low = [0 6 12 18 24];
in2Low = [0 25 50 75 100];

in2High=[0 0.25 0.5 0.75 1];

m=1;

for i=1:5
    for j=1:5
        for k=1:5
            st1(m,1)=in1Low(i);
            st2(m,1)=in2Low(j);
            st3(m,1)=in2High(k);
            m=m+1;
        end;
    end;
end;

lFis = readfis('BatulevTrainFis');
hFis = readfis('TrainBrakingDistancesFis');

in1= evalfis([st1,st2], lFis);
out=evalfis([in1, st3], hFis);

srt = [st1 st2 st3 out];