 str = [0 0 0];

 m=1;
step = 0.3;
for i=0:step:1
    for j=0:step:1
        for k=0:step:1
            str(m,1)=i ;      
            str(m,2)=j; 
            str(m,3)= k; 
            m=m+1;
        end;
    end;
end;
 
  fis = readfis('Batulev');
  SecondfisOut = evalfis([str(:,1),str(:,2),str(:,3)],fis);
  out=[str(:,1) str(:,2) str(:,3) SecondfisOut];
  