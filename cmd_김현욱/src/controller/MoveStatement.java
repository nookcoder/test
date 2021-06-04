package controller;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.List;

import model.CmdModel;
import view.CmdView;

public class MoveStatement {
	private CmdView view;
	private CmdController controller;
	private CmdModel model;	
	private CopyStatement copy; 
	
	public MoveStatement(CmdView view,CmdController controller,CmdModel model)
	{
		this.view = view;
		this.controller = controller;
		this.model = model;
	}
	
	// copy 명령문 실행 
	public void runMoveStatement(List<String> userStatementList)
	{
		if(userStatementList.size() == 3)
		{
			// 같은경로에 복사할때 
			if(!userStatementList.get(1).contains(File.separator) && !userStatementList.get(2).contains(File.separator))
			{
				moveFileWithNoPath(userStatementList);
			}
			else if(userStatementList.get(1).contains(File.separator) && !userStatementList.get(2).contains(File.separator))
			{
				moveFileWithNoPath(userStatementList);
			}
			
			else if(userStatementList.get(1).contains(File.separator) && !userStatementList.get(2).contains(File.separator))
			{
				moveFileWithNoPath(userStatementList);
			}
			// 경로가 모두 입력될때 
			else if(userStatementList.get(1).contains(File.separator) && userStatementList.get(2).contains(File.separator))
			{
				moveFileWithNoPath(userStatementList);
			}
		}
		
		else if(userStatementList.size() == 1)
		{
			view.showErrorSyntax();
			view.showRoute(controller.routeName);
		}
	}
	
	
	public void runMove(String originalPath, String movePath)
	{
		// 복사할 파일이 존재할 때 
		if(model.isExistsFile(originalPath))
		{
			try {
				model.copyFile(originalPath,movePath);
				model.deleteFile(originalPath);
			} catch (FileNotFoundException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			view.showSuccessMove();
			view.showRoute(controller.routeName);
		}
		
		//isDirectory 추가 
		
		// 복사파일이 없을 때 
		else
		{
			view.showNoExistsOriginalFile();
			view.showRoute(controller.routeName);
		}
	}
	
	public void moveFileWithNoPath(List<String> userStatementList)
	{
		String originalPath = controller.routeName + File.separator+userStatementList.get(1);
		String copyPath = controller.routeName + File.separator+userStatementList.get(2);
		runMove(originalPath,copyPath);
	}
	
	// 이동해올 파일 경로만 일력됐을 때 
	public void moveFileWithOriginalPath(List<String> userStatementList)
	{
		String originalPath = userStatementList.get(1);
		String copyPath = controller.routeName + File.separator+userStatementList.get(2);
		runMove(originalPath,copyPath);
	}
	
	// 이동될 파일 경로만 입력됐을 때 
	public void moveFileWithCopyPath(List<String> userStatementList)
	{
		String originalPath = controller.routeName + File.separator+userStatementList.get(1);
		String copyPath = userStatementList.get(2);
		runMove(originalPath,copyPath);
	}
	
	// 경로 두개 입력 됐을 때 
	public void moveFileWithTwoPath(List<String> userStatementList)
	{
		String originalPath = userStatementList.get(1);
		String copyPath = userStatementList.get(2);
		runMove(originalPath,copyPath);
	}
}
