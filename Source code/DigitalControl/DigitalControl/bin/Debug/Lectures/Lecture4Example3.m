clear
clc
path = mfilename('fullpath');
full_path = [path '.txt'];
delete(full_path)
diary(full_path)

num = [2, 1, 0, 0];
den = [1, 0, 1, 1];
[r, p, k] = residue(num, den) 

diary off