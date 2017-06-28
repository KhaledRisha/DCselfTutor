clear
clc
path = mfilename('fullpath');
full_path = [path '.txt'];
delete(full_path)
diary(full_path)

Delta = [1 zeros(1, 4)];
num = [1 1 0];
den = [1 -3 4];
yk = filter(num, den, Delta)

diary off