function matlab2text()
    [pathstr] = fileparts(mfilename('fullpath'));
    files = what(pathstr);
    for i = 1 : length(files.m)
        m_file = char(files.m(i));
        file_name = m_file(1:((length(m_file))-2));
        copyfile(m_file, [file_name '[TEXT]' '.txt']);
    end
end