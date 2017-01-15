function [ TestSample ] = GetTestSample(xMax, yMax,X,Y,M )

TestX = rand(100,1) * xMax;
TestY = rand(100,1) * yMax;
Test=zeros(100,1);

for i=1:100 
    Test(i,1) = GetPoint(X, Y, M, TestX(i,1), TestY(i,1)); 
end

TestSample = [TestX, TestY, Test];

end

