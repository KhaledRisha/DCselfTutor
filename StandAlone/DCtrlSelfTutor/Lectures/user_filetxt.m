function user_file(path,lec_num,ex_num)
     copyfile( path, ['Lecture' lec_num 'Example' ex_num '(Question).txt'] );
%    movefile( ['Lecture' lec_num 'Example' ex_num '.m'],  'C:\DigitalControl\');
end
