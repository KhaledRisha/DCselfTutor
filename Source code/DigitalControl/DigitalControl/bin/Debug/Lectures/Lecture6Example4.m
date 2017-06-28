clear
clc
path = mfilename('fullpath');
full_path = [path '.txt'];
delete(full_path)
diary(full_path)

s = tf('s');
G = 1 / (s + 1);
Gd = c2d(G, 1); % zoh is the default conversion method for c2d!
t = 0 : 1 : 10;
y = step(Gd, t)
figure('visible','off');
plot(t, y, 'o', t, y);

print(path,'-dpng')
diary off