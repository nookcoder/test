package controller;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.List;
import java.util.Scanner;

import model.CmdModel;
import model.Constants;
import model.Copy;
import view.CmdView;

public class CopyStatement {
	
	private CmdView view;
	private CmdController controller;
	private CmdModel model;
	private Copy copy; 
	private Constants constants;
	private Scanner scan;
	
	public CopyStatement(CmdView view,CmdController controller, CmdModel model, Constants constants)
	{
		this.view = view;
		this.controller = controller;
		this.model = model;
		this.constants = constants;
		this.copy = new Copy();
		this.scan = new Scanner(System.in);
	}
	
	// copy 명령문 실행 
	public void runCopyStatement(List<String> userStatementList)throws IOException
	{
		if(userStatementList.size() == 3)
		{
			runCopy(userStatementList);
		}
		
		else if(userStatementList.size() == 1)
		{
			view.showErrorSyntax();
			view.showRoute(controller.routeName);
		}
	}
	
	public void runCopy(List<String> userStatementList) throws IOException
	{
		String sourcePath = model.makeCopyPathName(controller.routeName,userStatementList.get(1));
		String copyPath = model.makeCopyPathName(controller.routeName,userStatementList.get(2));
		
		File source = new File(sourcePath); 
		File destination = new File(copyPath);
		
		int catagory = model.checkCatagory(source, destination);
		
		switch(catagory)
		{
			//case constants.FILE_FILE:
			case 0:
				view.showNoExistsOriginalFile();
				view.showRoute(controller.routeName);
				break;
			case 1: // File_File
				copyFileToFile(sourcePath,copyPath,userStatementList);
				break;
				
			case 2: // File_Directory
				copyFileToDirectory(sourcePath,copyPath,userStatementList);
				break;
				
			case 3: // Directory_File
				copyDirectoryToFile(sourcePath,copyPath,userStatementList);
				break;
				
			case 4: // Directory_Directory
				copyDirectoryToDirectory(sourcePath,copyPath,userStatementList);
				break;
		}
	}
	
	public void copyFileToFile(String sourcePath, String copyPath,List<String> userStatementList) throws IOException
	{
		File source = new File(sourcePath); 
		File destination = new File(copyPath);
		
		if(sourcePath.equals(copyPath))
		{
			view.showFailCopy();
			view.showRoute(controller.routeName);
			return;
		}
		
		if(destination.exists())
		{
			String answer =constants.INITIALIZATION_STRING;
			while(answer.charAt(0) != 'y' && answer.charAt(0) != 'a' && answer.charAt(0) != 'n')
			{
				view.askOverWrite(userStatementList.get(2));
				answer = scan.next().toLowerCase();
				
			}
			if(answer.charAt(0) == 'y' || answer.charAt(0) == 'a')
			{
				copy.FileToFile(source, destination);
				view.showSuccessCopy();
				view.showRoute(controller.routeName);
				return;
			}
			
			else if(answer.charAt(0) == 'n')
			{
				view.showNumberOfCopy(0);
				view.showRoute(controller.routeName);
				return;
			}
		
		}
		
		copy.FileToFile(source, destination);
		view.showSuccessCopy();
		view.showRoute(controller.routeName);
	}
	
	public void copyFileToDirectory(String sourcePath, String copyPath,List<String> userStatementList) throws IOException
	{
		File source = new File(sourcePath); 
		File destination = new File(copyPath);
		String checkPath = copyPath + File.separator + source.getName();
		File check = new File(checkPath);
		if(check.exists())
		{
			String answer =constants.INITIALIZATION_STRING;
			while(answer.charAt(0) != 'y' && answer.charAt(0) != 'a' && answer.charAt(0) != 'n')
			{
				view.askOverWrite(userStatementList.get(2)+File.separator + source.getName());
				answer = scan.next().toLowerCase();
				
			}
			if(answer.charAt(0) == 'y' || answer.charAt(0) == 'a')
			{
				copy.FileToDirectory(source, destination);
				view.showSuccessCopy();
				view.showRoute(controller.routeName);
				return;
			}
			
			else if(answer.charAt(0) == 'n')
			{
				view.showNumberOfCopy(0);
				view.showRoute(controller.routeName);
				return;
			}
		}
		
		
		
		copy.FileToDirectory(source, destination);
		view.showSuccessCopy();
		view.showRoute(controller.routeName);
	}
	
	public void copyDirectoryToFile(String sourcePath, String copyPath,List<String> userStatementList) throws IOException
	{
		File source = new File(sourcePath); 
		File destination = new File(copyPath);
		
		if(destination.exists())
		{
			String answer =constants.INITIALIZATION_STRING;
			while(answer.charAt(0) != 'y' && answer.charAt(0) != 'a' && answer.charAt(0) != 'n')
			{
				view.askOverWrite(userStatementList.get(2));
				answer = scan.next().toLowerCase();
				
			}
			if(answer.charAt(0) == 'y' || answer.charAt(0) == 'a')
			{
				DirectoryToFile(source, destination,userStatementList);
				view.showSuccessCopy();
				view.showRoute(controller.routeName);
				return;
			}
			
			else if(answer.charAt(0) == 'n')
			{
				view.showNumberOfCopy(0);
				view.showRoute(controller.routeName);
				return;
			}
		}
		
		DirectoryToFile(source,destination,userStatementList);
		view.showSuccessCopy();
		view.showRoute(controller.routeName);
	}
	
	public void copyDirectoryToDirectory(String sourcePath, String copyPath,List<String> userStatementList) throws IOException
	{
		File source = new File(sourcePath); 
		File destination = new File(copyPath);
		
		copy.DirectoryToDirectory(source,destination);
		view.showSuccessCopy();
		view.showRoute(controller.routeName);
	}
	
	public void DirectoryToFile(File originalFile, File copyFile,List<String> userStatementList) throws IOException
	{
		File[] targetFile = originalFile.listFiles();
		boolean isFirst = true;
		boolean isYes = false; 
		FileOutputStream destination;
		String answer = constants.INITIALIZATION_STRING;

		for(File file:targetFile)
		{
			if(file.isFile()) {
				FileInputStream origin = new FileInputStream(file);
				
				
				while(answer.charAt(0) != 'y' && answer.charAt(0) != 'a' && answer.charAt(0) != 'n' && !isYes)
				{
					System.out.println(userStatementList.get(1) + File.separator + file.getName());
					view.askOverWrite(userStatementList.get(2));
					answer = scan.next().toLowerCase();
				}
				
				if(answer.charAt(0) == 'y' || answer.charAt(0) == 'a' || isYes)
				{
					if(isFirst)
					{
						destination = new FileOutputStream(copyFile,false);					
						isFirst = false;
						isYes = true;
					}
					else
					{
						destination = new FileOutputStream(copyFile,true);
						isYes = true;
					}

					copy.runWrite(origin,destination);
				}

				else if(answer.charAt(0) == 'n')
				{
					continue;
				}

				
			}
		}
	}
	
}
