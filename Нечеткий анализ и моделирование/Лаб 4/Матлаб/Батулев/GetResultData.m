function [ result ] = GetResultData( X,Y,M,in1Arr,in2Arr )

result=zeros(100,1);

for i=1:100 
    result(i,1) = GetPoint(X, Y, M, in1Arr(i,1), in2Arr(i,1)); 
end

end

