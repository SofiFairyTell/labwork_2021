x = [1:1:24];
n= length(x);
y = zeros(1,n);
for i = 1:n 
if x(i) <=10 y(i)=0;
elseif x(i)>=21 y(i)=1;
else  y(i) = -0.0016*x(i)*x(i)*x(i)+0.0711*x(i)*x(i) - 0.9271*x(i)+3.7478;
end;
end;
% Построение концентрации CON
cony=zeros(1,n);
for i=1:n  
    cony(i)= y(i)^2;
end
plot(x,y,':')
hold on
plot(x,cony);
hold off
% Построение растяжения DIL
dily=zeros(1,n);
for i=1:n  
    dily(i)= y(i)^(1/2);
end
plot(x,y,'*')
hold on
plot(x,dily);
hold off


