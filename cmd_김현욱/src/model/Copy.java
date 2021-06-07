package model;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class Copy {
	
	private Constants constants;
	
	public Copy()
	{
		this.constants = new Constants();
	}
	
	public void FileToFile(File source, File destination) throws IOException
	{
		FileInputStream origin = new FileInputStream(source);
		FileOutputStream copy = new FileOutputStream(destination);
		
		runWrite(origin,copy);
	}
	
	public void FileToDirectory(File source, File destination) throws IOException
	{
		FileInputStream origin = new FileInputStream(source);
		File temp = new File(destination.getAbsoluteFile() + File.separator + source.getName());
		FileOutputStream copy = new FileOutputStream(temp);
		
		runWrite(origin,copy);
	}
	
	public void DirectoryToFile(File originalFile, File copyFile) throws IOException
	{
		File[] targetFile = originalFile.listFiles();
		boolean isFirst = true;
		FileOutputStream copy;
		for(File file:targetFile)
		{
			if(file.isFile()) {
				FileInputStream origin = new FileInputStream(file);
				if(isFirst)
				{
					copy = new FileOutputStream(copyFile,false);					
					isFirst = false;
				}
				else
				{
					copy = new FileOutputStream(copyFile,true);
				}
				
				runWrite(origin,copy);
			}
		}
	}

	
	public void DirectoryToDirectory(File originalFile, File copyFile) throws IOException
	{
		File[] targetFile = originalFile.listFiles();
		for(File file : targetFile)
		{
			File temp = new File(copyFile.getAbsoluteFile() + File.separator + file.getName());				
			
			if(file.isFile()){
				FileInputStream origin = new FileInputStream(file);
				FileOutputStream copy = new FileOutputStream(temp);
				
				runWrite(origin,copy);
			}
		}
	}
	
	public void runWrite(FileInputStream origin,FileOutputStream copy) throws IOException
	{
		int count = 0;
		while((count = origin.read()) != constants.END_FILE)
		{
			copy.write(count);
		}
		
		origin.close();
		copy.close();
	}
	
	
}
