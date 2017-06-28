clear
warning('off','all')
[pathstr,name] = fileparts(mfilename('fullpath'));
files = what(pathstr);
for i = 1 : length(files.m)
    if (bi2de(isstrprop((char(files.m(i))), 'upper')) == 257)
        file_name = char(files.m(i));
        prepend_append(file_name)
        path_organizer(file_name);
    end    
end
