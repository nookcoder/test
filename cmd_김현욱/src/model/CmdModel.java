package model;

import java.io.File;
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
}
