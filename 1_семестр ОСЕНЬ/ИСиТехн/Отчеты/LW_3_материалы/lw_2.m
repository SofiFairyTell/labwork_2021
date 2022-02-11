x = 0:0.1:10; 
y1 = psigmf(x,[1 5 -5 6]); 
y2 = psigmf(x,[8 7 -1 6]); 
xlabel('psigmf, P1 = [1 5 -5 6], P2 = [8 7 -1 6]')
ylim([-0.05 1.05])

% plot(x,y1) 
% plot(x,y2) 

ymin = min([y1;y2]);
ymax = max([y1;y2]);
noty = 1-y1;

hold on
plot(x,y1,':'); 
plot(x,y2,':');

%график двух функций
%plot(x,[y1;y2],':');

%график конъюнкции
plot(x,ymin,'*');

%график дизъюнкции
plot(x,ymax,'+');


%график отрицания
plot(x,noty,'-');

hold off
