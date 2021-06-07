package model;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.List;

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
	
	public String makePath2(List<String> userStatementList,String currentPath) throws IOException
	{
		String newPath = ""; 
		String path = ""; 
		
		for(int index=1;index<userStatementList.size();index++)
		{
			path = path+ " "+userStatementList.get(index);
		}
		
		if(path.contains("c:")||path.contains("C:"))
		{
			newPath = path.trim().toLowerCase(); 
		}
		
		else
		{
			newPath = currentPath + File.separator + path.trim().toLowerCase(); 
		}
		
		return getFileRouteName(newPath); 
	}
	
	public boolean isHiddenFile(File file)
	{
		if(file.isHidden())
		{
			return true;
		}
		
		return false;
	}
	
	public String getCurrentFileName(String routeName)
	{
		int lastSeparatorIndex = routeName.lastIndexOf(File.separator);
		String currentFileName = routeName.substring(lastSeparatorIndex+1, routeName.length());
		
		return currentFileName;
	}
	
	public long getFileInfoFromParentFile(String routeName) {
		File file = new File(routeName);
		File parentFile = file.getParentFile(); 
		File[] parentFiles = parentFile.listFiles();
		String currentFileName = getCurrentFileName(routeName);
		
		for(File components : parentFiles)
		{
			if(components.getName().equals(currentFileName))
			{
				return components.lastModified();
			}
		}
		
		return 0;
	}
	
	// 문자열에서 . \ / 삭제
	public String deleteChar(String str)
	{
		str = str.replaceAll("[.\\/]", "");	
		return str;
	}
		
	// 문자열에 . / \ 를 제외한 문자열이 있는 지 확인 
	public boolean isHavingText(List<String> userStatementList)
	{
		boolean isHaving = false;

		for(int index=1; index < userStatementList.size(); index++)
		{
			if(!deleteChar(userStatementList.get(index)).equals(""))
			{
				isHaving = true;
			}
		}

		return isHaving;
	}
}
