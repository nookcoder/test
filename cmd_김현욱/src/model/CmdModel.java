package model;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;

public class CmdModel {
	private File file; 
	public String routeName; 
	
	
	public CmdModel() {
		this.routeName = System.getProperty("user.home");; 		
	}
	
	public boolean isExistsFile(String pathName)
	{
		file = new File(pathName);  
		
		return file.exists();
	}
	
	public String getFileRouteName(String pathName) throws IOException
	{
		file = new File(pathName);
		
		return file.getCanonicalPath();
	}
	
	// 한칸 뒤로가기 
	public String backOneRoute(String routeName) throws IOException
	{
		int seperateIndex; 
		if(routeName.equals("C:")||routeName.equals("c:"))
		{
			return routeName;
		}

		seperateIndex = routeName.lastIndexOf(File.separator); 
		routeName = routeName.substring(0, seperateIndex);

		return routeName;
	}
	
	
	public void copyFile(String originalPath, String copyPath) throws FileNotFoundException
	{
		int fileByte;
		
		File originalFile = new File(originalPath);
		File copyFile = new File(copyPath);
		
		FileInputStream InputFile = new FileInputStream(originalFile); 
		FileOutputStream outFile = new FileOutputStream(copyFile);
	
		fileByte = 0;
		try {
			while((fileByte = InputFile.read()) != -1)
			{
				outFile.write(fileByte);
			}
			
			InputFile.close();
			outFile.close();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
