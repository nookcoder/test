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
	
	public void copyFile(File originalFile, File copyFile)
	{
		try {

			FileInputStream fis = new FileInputStream(originalFile); //읽을파일
			FileOutputStream fos = new FileOutputStream(copyFile); //복사할파일

			int fileByte = 0; 
			
			while((fileByte = fis.read()) != -1) {
				fos.write(fileByte);
			}
			//자원사용종료
			fis.close();
			fos.close();

		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
    }
	
	
	public void copyDirectory(File originalFile, File copyFile)
	{
		File[] targetFile = originalFile.listFiles();
		
		for(File file : targetFile)
		{
			File temp = new File(copyFile.getAbsoluteFile() + File.separator + file.getName());
			if(file.isDirectory()) {
				temp.mkdir();
				copyFile(file,temp);
			}else {
				FileInputStream InputFile =null;  
				FileOutputStream outFile = null; 
				try{
					InputFile = new FileInputStream(file);
					outFile = new FileOutputStream(temp);
					byte[] fileByte = new byte[4096];
					int count = 0;
					while((count = InputFile.read(fileByte)) != -1) {
						outFile.write(fileByte,0,count);
					}
				} catch (Exception e) {
					e.printStackTrace();
				}finally {
					try {
						InputFile.close();
						outFile.close();

					} catch (IOException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}	
				}
			}
		}
	}
	
	public void deleteFile(String filePath)
	{
		File deleteFile = new File(filePath);
		
		deleteFile.delete();
	}
	
	public String makePath(String currentPath,String path)
	{
		String newPath = ""; 
		
		if(path.contains("c:"))
		{
			newPath = path; 
			return newPath; 
		}
		
		newPath = currentPath + File.separator + path; 
		
		return newPath; 
	}
}
