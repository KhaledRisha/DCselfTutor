function path_organizer(file_name)
    lecture = file_name(1:8);
    example = file_name(9:18);
    mkdir(lecture)
    movefile(file_name,example);
    movefile(example,lecture);
    copyfile('matlab2text.m',lecture);
end