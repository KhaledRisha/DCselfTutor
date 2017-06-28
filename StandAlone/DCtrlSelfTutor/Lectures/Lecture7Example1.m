clear
clc
path = mfilename('fullpath');
full_path = [path '.txt'];
delete(full_path)
diary(full_path)

equation_roots = roots([2 1 1 1])
absolute_value = abs(roots([2 1 1 1]))

diary off