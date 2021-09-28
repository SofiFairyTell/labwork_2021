x = [1:1:24];
n= length(x);
y = zeros(1,n);
for i = 1:n 
if x(i) <=10 y(i)=0;
elseif x(i)>=21 y(i)=1;
else  y(i) = -0.0016*x(i)*x(i)*x(i)+0.0711*x(i)*x(i) - 0.9271*x(i)+3.7478;
end;
end;
plot(x,y);