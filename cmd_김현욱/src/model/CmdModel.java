package model;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.List;

public class CmdModel {
	private File file; 
	private Constants constants;
	public String routeName; 
	
	
	public CmdModel() {
		this.routeName = System.getProperty("user.home");; 		
		this.constants = new Constants();
	}
	
	public boolean isExistsFile(String pathName)
	{
		file = new File(pathName);  
		
		return file.exists();
	}
	
	public String getFileRouteName(String pathName) throws IOException
	{
		pathName = pathName.trim().toLowerCase();
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
	
	public int checkCatagory(File source, File destination)
	{
		if(!source.exists() || !destination.getParentFile().exists())
		{
			return 0; 
		}
		
		else if(source.isFile() && destination.isFile())
		{
			return 1; 
		}
		
		else if(source.isFile() && destination.isDirectory())
		{
			return 2;
		}
		
		else if(source.isDirectory() && destination.isFile())
		{
			return 3;
		}
		
		else if(source.isDirectory() && destination.isDirectory())
		{
			return 4;
		}
		
		else if(source.isDirectory() && destination.getParentFile().exists())
		{
			return 3;
		}
		
		return 1;
		
	}
	
	
	public void deleteFile(String filePath)
	{
		File deleteFile = new File(filePath);
		
		deleteFile.delete();
	}
	
	// cd, dir 경로 만들기 
	public String makePath(List<String> userStatementList,String currentPath,int startIndex) throws IOException
	{
		String newPath = ""; 
		String path = ""; 
		
		for(int index=startIndex;index<userStatementList.size();index++)
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
	
	// 숨겨진 파일인지 확인 하기 
	public boolean isHiddenFile(File file)
	{
		if(file.isHidden())
		{
			return true;
		}
		
		return false;
	}
	
	// 현재 파일 이름 가져오기 
	public String getCurrentFileName(String routeName)
	{
		int lastSeparatorIndex = routeName.lastIndexOf(File.separator);
		String currentFileName = routeName.substring(lastSeparatorIndex+1, routeName.length());
		
		return currentFileName;
	}
	
	// 부모 폴더에서 최근 수정일자 받아오기 
	public long getFileInfoFromParentFile(String routeName) {
		if(!routeName.equals("C:"))
		{
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
	
	// 복사, 이동 경로 만들기 
	public String makeCopyPathName(String currentRoute, String inputPath)
	{
		if(!inputPath.toLowerCase().contains("c:"))
		{
			inputPath = currentRoute+ File.separator + inputPath;  
		}
		
		return inputPath;
	}
	
	
}
