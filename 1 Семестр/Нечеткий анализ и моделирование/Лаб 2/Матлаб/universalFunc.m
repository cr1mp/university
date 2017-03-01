function [ D1, M1, S1 ] = universalFunc( A,B )

D1 = abs(A-B);
M1 = max(max(D1));
t = size(D1);
S1 = sum(sum(D1))/(t(1)*t(2));

end

