clear
clc
path = mfilename('fullpath');
full_path = [path '.txt'];
delete(full_path)
diary(full_path)

% Deadbeat control : D(z) = (z^3 - 0.904 z ^2) / (0.095 (z^3 - 1))
Gp = tf (1 ,[10 1], 'iodelay' ,2);
Gpd = c2d (Gp ,1);
Gc = tf ([1 -0.904 0 0] ,[0.095 0 0 -0.095] ,1) ;
Gcl =Gc* Gpd /(1+ Gc* Gpd );
t =0:1:10;
y= step (Gcl ,t)
figure('visible','off');
plot (t,y,'o');
hold on; 
stairs (t,y); 
hold off;
xlabel ('time , t');
ylabel ('output , y');
axis ([0 10 0 1.2]);
title ('Step response ');

print(path,'-dpng')

Gru =Gc /(1+ Gc* Gpd );
u= step (Gru ,t)
figure('visible','off'); 
plot (t,u,'o'); 
hold on; 
stairs (t,u); 
hold off;
xlabel ('time , sec ');
ylabel ('control signal , u');
axis ([0 10 0 15]);
title ('Control signal ');

path = [path '_2'];
print(path,'-dpng')
diary off