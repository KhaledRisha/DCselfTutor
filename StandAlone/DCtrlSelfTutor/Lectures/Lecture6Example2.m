clear
clc
path = mfilename('fullpath');
full_path = [path '.txt'];
delete(full_path)
diary(full_path)

u = ones(size(0 : 10)); % Define input to be 1 from samples 0 to 10
num = [0, 0.1813]; % Numerator coefficients of z
den = [1, -0.8187]; % Denominator coefficients of z
y = dlsim(num, den, u)
figure('visible','off');
plot(0 : 10, y, 'o', 0 : 10, y); % Plot samples as 'o' connected by lines

print(path,'-dpng')
diary off