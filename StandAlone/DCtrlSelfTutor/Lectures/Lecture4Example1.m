clear
clc
path = mfilename('fullpath');
full_path = [path '.txt'];
delete(full_path)
diary(full_path)

G = tf([1],[1,5,6]); % continuous time transfer function
T = 1;
Gd = c2d(G,T,'impulse') %discrete time transfer function

diary off