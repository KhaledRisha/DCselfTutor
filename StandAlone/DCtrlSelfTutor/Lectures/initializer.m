warning('off','all')
[pathstr, name] = fileparts(mfilename('fullpath'));
files = what(pathstr);
for i = 1 : length(files.m)
    m_file_name = char(files.m(i));
    magic_number = bi2de(isstrprop(m_file_name, 'upper'));
    if (magic_number == 257)
        path_organizer(m_file_name);
    end
end