function result = Cicle
x=1;
for j =0:0.1:10
    for i = 0:0.1:10
        result(x,1)= i;
        result(x,2)= j;
        x=x+1;
    end
end
end

