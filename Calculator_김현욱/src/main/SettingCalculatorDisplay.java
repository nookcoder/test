package main;

import java.awt.Color;
import java.awt.GridBagLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.*;

public class SettingCalculatorDisplay extends JPanel
{
	private JPanel displayPanel;
	private JPanel keyPadPanel;
	private JTextField textArea; 
	private JPanel noticePanel;
	private JLabel label;
	private JLabel textNotice;
	private JButton[] numberButton;
	private JButton ce; 
	private JButton c; 
	private JButton backSpace;
	private JButton divide;
	private JButton plus;
	private JButton equal;
	private JButton minus;
	private JButton multiply;
	private JButton dot;
	private JButton changingSign;
	
	private Constants constant;
	
	private String lastedOperator; // 가장 최근에 입력된 사칙연산 기호 
	private Double doubleNum;
	private Double doubleSum;
	private boolean isNewNumberStart; // 새로운 숫자가 입력되는 지 판단
	private boolean isEqualNext; // = 를 누른 후 다음 이벤트인지 판단
	private boolean isFirstNumber; // 계산 과정에서 첫번째 입력 숫자인지 확인 
	private boolean isOperatorNext; // 가장 최근에 입력된 게 연산 기호인지 확인 
	
	public SettingCalculatorDisplay() {
		setLayout(new BoxLayout(this,BoxLayout.Y_AXIS));
		
		this.constant = new Constants();
		
		// 계산과정에서 쓰일 변수들 초기화 
		this.doubleNum = 0.0;
		this.doubleSum = 0.0; 
		this.lastedOperator = null;
		this.isNewNumberStart = true;
		this.isFirstNumber = true;
		this.isEqualNext = false;
		this.isOperatorNext = false; 
		
		this.displayPanel = new JPanel(); // 숫자표시칸 관련 패널 
		this.keyPadPanel = new JPanel(); // 숫자패드 관련 패널 
		this.noticePanel = new JPanel();
		noticePanel.setLayout(new GridLayout(0,1));
		
		this.keyPadPanel = new JPanel(); 
		this.numberButton = new JButton[10];
		
		// 숫자 버튼 설정 
		for(int number = 0; number<10;number++)
		{
			numberButton[number] = new JButton(Integer.toString(number));
			setButtonFont(numberButton[number]);
			
			numberButton[number].addActionListener(new NumberButtonListener());
		}
		
		this.plus = new JButton("+");
		this.minus = new JButton("ㅡ");
		this.multiply = new JButton("X");
		this.divide = new JButton("/");
		this.c = new JButton("C");
		
		this.ce = new JButton("CE");
		this.dot = new JButton(".");
		this.changingSign = new JButton("+/-");
		this.equal = new JButton("=");
		this.backSpace = new JButton("BACK");
	
		// 연산기호 버튼 커스텀
		setSignButtonFont(plus);
		setSignButtonFont(minus);
		setSignButtonFont(multiply);
		setSignButtonFont(c);
		setSignButtonFont(ce);
		setButtonFont(dot);
		setButtonFont(changingSign);
		setSignButtonFont(equal);
		setSignButtonFont(backSpace);
		setSignButtonFont(divide);
		
		// 연산 기호 이벤트 처리 
		plus.addActionListener(new OperatorListener());
		minus.addActionListener(new OperatorListener());
		multiply.addActionListener(new OperatorListener());
		divide.addActionListener(new OperatorListener());
		equal.addActionListener(new EqualListener());
		c.addActionListener(new ResetListener());
		ce.addActionListener(new ResetListener()); 
		dot.addActionListener(new DotListener());
		changingSign.addActionListener(new ChangingSignListener());
		backSpace.addActionListener(null);

		// 숫자패드 만들기
		keyPadPanel.add(ce);
		keyPadPanel.add(c);
		keyPadPanel.add(backSpace);
		keyPadPanel.add(divide);
		
		keyPadPanel.add(numberButton[7]);
		keyPadPanel.add(numberButton[8]);
		keyPadPanel.add(numberButton[9]);
		keyPadPanel.add(multiply);
		
		keyPadPanel.add(numberButton[4]);
		keyPadPanel.add(numberButton[5]);
		keyPadPanel.add(numberButton[6]);
		keyPadPanel.add(minus);
		
		keyPadPanel.add(numberButton[1]);
		keyPadPanel.add(numberButton[2]);
		keyPadPanel.add(numberButton[3]);
		keyPadPanel.add(plus);
		
		keyPadPanel.add(changingSign);
		keyPadPanel.add(numberButton[0]);
		keyPadPanel.add(dot);
		keyPadPanel.add(equal);
		
		keyPadPanel.setLayout(new GridLayout(5,4,2,2));
		
		this.textArea = new JTextField("0");
		this.textNotice = new JLabel("1");
		this.label = new JLabel();
		label.add(new JButton());
		//label.setHorizontalAlignment(JLabel.RIGHT);
		noticePanel.add(label);
		noticePanel.add(textNotice);
		noticePanel.setLayout(new GridLayout(0,1));
		
		textArea.setText("0"); 
		textArea.setHorizontalAlignment(JTextField.RIGHT);
		textArea.setFont(constant.font);
		displayPanel.setLayout(new GridLayout(0,1));
		displayPanel.add(noticePanel);
		displayPanel.add(textArea);
		add(displayPanel);
		add(keyPadPanel);
		}		
	
	public void setButtonFont(JButton btn) {
		btn.setFont(constant.font);
		btn.setBorderPainted(false);
		btn.setBackground(Color.WHITE);
	}
	
	public void setSignButtonFont(JButton btn) {
		btn.setFont(constant.signFont);
		btn.setBorderPainted(false);
		btn.setBackground(Color.LIGHT_GRAY);
	}
	
	public void runOperation(String operator)
	{
			if(operator == "+") {doubleSum += doubleNum;}
			else if(operator == "ㅡ") {doubleSum -= doubleNum;}
			else if(operator == "X") {doubleSum *= doubleNum;}
			else if(operator == "/") {doubleSum /= doubleNum;}
	}
	
	public void setPrintingNumberToInt(Double number)
	{
		String[] numberString = number.toString().split(".");
		if(numberString[1].equals("0")) {
			textArea.setText(numberString[0]);
		}
		else {
			textArea.setText(number.toString());
		}
		
	}
	
	public void reset() {
		isNewNumberStart  = true; 
		isFirstNumber = true;
		isEqualNext = false;
		isOperatorNext = false;
		lastedOperator = null;
		
		doubleNum = 0.0;
		doubleSum = 0.0;
	}
	
	// 숫자 키 입력 시 이벤트 처리 
	private class NumberButtonListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e){
			JButton numberButton = (JButton)e.getSource();
			String number = numberButton.getText();
			String result = textArea.getText(); 
			
			if(isEqualNext)
			{
				reset();
				textArea.setText(number);
			}
			
			// 새로운 숫자 입력시 기존 쓰여져있던 숫자 지우기 
			if(isNewNumberStart ||result.equals("0")||isEqualNext)
			{
				textArea.setText("");
				textArea.setText(number);
			}					
			// 연속으로 숫자 입력 시 
			else {textArea.setText(result + number);}
			
			getNumber();
			
			// 연산 기호 다음 숫자일 떄 처리(계산해주는 과정) 
			isOperatorNext = false;
			isNewNumberStart = false;
			isEqualNext = false;
		}
		
		public void getNumber() {
			// 입력한 숫자 저장 
			if(isFirstNumber) {doubleSum = Double.valueOf(textArea.getText());}
			else{ doubleNum = Double.valueOf(textArea.getText());}
		}
	}
	
	// 연산 기호 이벤트 처리 
	private class OperatorListener implements ActionListener{
		public void actionPerformed(ActionEvent e ) {
			
			JButton operatorButton = (JButton)e.getSource();
			String operator = operatorButton.getText();
			
			if(lastedOperator  != null && !isEqualNext) {runOperation(lastedOperator);}

			lastedOperator = operator;	
			
			isOperatorNext = true;
			isNewNumberStart  = true;
			isEqualNext = false;
			isFirstNumber = false;
		}		
	}
	
	// 등호(=) 이벤트 처리 
	private class EqualListener implements ActionListener{
		public void actionPerformed(ActionEvent e)
		{
			if(!isOperatorNext)
			{
				isEqualNext = true;
				runOperation(lastedOperator);
				String doubleSumString = Double.toString(doubleSum);
				String doubleSumCheck = doubleSumString.substring(doubleSumString.length() - 1);
				
				if(doubleSumCheck.equals("0"))
				{
					textArea.setText(doubleSum.toString().substring(0, doubleSumString.length()-2));
				}
				
				else
				{
					textArea.setText(doubleSum.toString());
				}
			}
		}
	}
	
	// c ce 입력시 이벤트 처리 
	private class ResetListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e)
		{
			JButton resetButton = (JButton)e.getSource();
			
			// 완전 초기화 
			if(resetButton.getText() == "C")
			{
				textArea.setText("0");
				reset();
			}
			
			// 등호 다음 ce 입력 시 초기화, 계산과정중 ce입력시 숫자만 초기화 
			else if (resetButton.getText() == "CE")
			{
				textArea.setText("0");
				if(isEqualNext) {
					reset();
				}
			}
		}
	}

	// +/- 입력 이벤트 처리 
	private class ChangingSignListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e)
		{ 
			// 계산기에서 맨처음으로 입력할 떄 
			if(isNewNumberStart)
			{
				textArea.setText("");
				textArea.setText("-");
				isNewNumberStart = false;
				if(!textArea.getText().equals("-")) { doubleSum = Double.valueOf(textArea.getText());}
				return;
			}
			
			if(isFirstNumber) 
			{
				showChangeOperatorWithDouble(doubleSum);
				doubleSum = Double.valueOf(textArea.getText());
			}
			else
			{
				showChangeOperatorWithDouble(doubleNum);
				doubleNum = Double.valueOf(textArea.getText());
			}
		}
		
		// 부호 바뀌는 거 사용자에게 보여주는 함수 (실수)
		public void showChangeOperatorWithDouble(Double number) {
			
			if(number > 0)
			{
				textArea.setText("");
				textArea.setText("-" + number.toString());
			}
			
			else if(number < 0)
			{
				textArea.setText("");
				textArea.setText(number.toString());
			}
		}
	}
	
	private class DotListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e) {
			String oldString = textArea.getText();
			String newString = oldString + ".";
			
			if(!textArea.getText().contains(".")) {textArea.setText(newString);}
		}
		
	}
}



