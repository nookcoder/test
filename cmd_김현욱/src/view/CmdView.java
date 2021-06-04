package view;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;

public class CmdView {

	public void showWindowsVersion() throws IOException {
		Process process = Runtime.getRuntime().exec("cmd");
		InputStream inputStream = process.getInputStream();
		BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));
		System.out.println(reader.readLine());
		System.out.println("(c) Microsoft Corporation. All rights reserved.");
		showBlankLine();
	}
	
	// 경로를 찾을 수 없을 떄 안내문 
	public void showNoFindRoute()
	{
		System.out.println("지정된 경로를 찾을 수 없습니다."); 
		showBlankLine();
	}
	
	// 명령문이 틀렸을 때 안내문 
	public void showErrorStatement(String statement) {
		System.out.println("\'%c\'은(는) 내부 또는 외부명령, 실행할 수 있는 프로그램, 또는");
		System.out.println("배치 파일이 아닙니다.");
		showBlankLine();
	}
	
	public void showErrorConstruction()
	{
		System.out.println("파일 이름, 디렉터리 이름 또는 볼륨 레이블 구문이 잘못되었습니다.");
		showBlankLine();
	}
	
	public void showErrorSyntax()
	{
		System.out.println("명령 구문이 올바르지 않습니다.");
		showBlankLine();
	}
	
	public void showDeniedAccess()
	{
		System.out.println("액세스가 거부되었습니다.");
		showBlankLine();	}
	
	// 현재 경로 보여주기 
	public void showRoute(String route) {
		System.out.print(route + ">");
	}
	
	public void showBlankLine()
	{
		System.out.print("\n");
	}
}
