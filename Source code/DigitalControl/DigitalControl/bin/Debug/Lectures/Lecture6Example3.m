clear
clc
path = mfilename('fullpath');
full_path = [path '.txt'];
delete(full_path)
diary(full_path)

s = tf('s');
% continuous system
t = 0 : 0.1 : 35; 
G = 1 / (s^2 + s); 
Gcl = G / ( 1 + G)
y = step(Gcl, t);
figure('Visible','off');
plot(t, y, 'LineWidth', 2.5);
hold on;
% discrete system
% choose the sampling interval
T = 0.1;
Gd = c2d(G, T);
Gcld = Gd / (1 + Gd)
[y, t1] = step(Gcld);
plot(t1, y, '*r', 'LineWidth', 2.5);
axis([0 12 0 1.5]);

print(path,'-dpng')
diary off