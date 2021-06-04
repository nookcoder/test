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
}
