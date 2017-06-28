function prepend_append(mfile)
    %prepend
    tempFile = tempname;
    fw = fopen( tempFile, 'wt' );
    fwrite( fw, sprintf( 'warning(''off'',''all'')\nclear\nclc\npath = mfilename(''fullpath'');\nfull_path = [path ''.txt''];\ndelete(full_path)\ndiary(full_path)\n\n' ) );
    fclose( fw );
    fr = fopen( mfile, 'rt' );
    fw = fopen( tempFile, 'at' );
    while feof( fr ) == 0
        tline = fgetl( fr );
        fwrite( fw, sprintf('%s\n',tline ) );
    end
    fclose(fr);
    fclose(fw);
    copyfile( tempFile, mfile );      
    delete(tempFile);
    %append
    fa = fopen( mfile, 'a+t' );
    fwrite( fa, sprintf( '\ndiary off' ));
    fclose(fa);
end