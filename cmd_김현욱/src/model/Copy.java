package model;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class Copy {
	
	private Constants constants;
	
	public Copy(Constants constants)
	{
		this.constants = constants;
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
				
				byte[] fileByte = new byte[4096];
				int count = 0;
				while((count = origin.read(fileByte)) != constants.END_FILE)
				{
					copy.write(fileByte,0,count);
				}
				
				origin.close();
				copy.close();
			}
		}
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
				
				int count = 0;
				while((count = origin.read()) != constants.END_FILE)
				{
					copy.write(count);
				}
				
				origin.close();
				copy.close();
			}
		}
	}
	
	public void FileToFile(File source, File dest) throws IOException
	{
		FileInputStream origin = new FileInputStream(source);
		FileOutputStream copy = new FileOutputStream(dest);
		
		byte[] fileByte = new byte[4096];
		int count = 0;
		while((count = origin.read(fileByte)) != constants.END_FILE)
		{
			copy.write(fileByte,0,count);
		}
		
		origin.close();
		copy.close();
	}
	
}
