package main;

import java.awt.BorderLayout;
import java.awt.Component;
import java.awt.Container;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.*;

public class SettingCalculatorDisplay extends JPanel
{
	private JPanel displayPanel;
	private JPanel keyPadPanel;
	
	static JTextField textArea; 
	
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
	private int num; // 입력된 숫자 
	private int sum; // 출력될 계산 결과 값
	private boolean isNewNumberStart  = true; // 새로운 숫자가 입력되는 지 판단
	private boolean isEqualNext = false; // = 를 누른 후 다음 이벤트인지 판단
	private boolean isFirstNumber = true; // 계산 과정에서 첫번째 입력 숫자인지 확인 
	private boolean isOperatorNext = false; // 가장 최근에 입력된 게 연산 기호인지 확인 
	private boolean isChanging = false; 
	
	public SettingCalculatorDisplay() {
		this.constant = new Constants();
		
		// 계산과정에서 쓰일 변수들 초기화 
		this.num = 0; 
		this.sum = 0;
		this.lastedOperator = null;
		this.isNewNumberStart = true;
		this.isFirstNumber = true;
		this.isEqualNext = false;
		this.isOperatorNext = false; 
		
		this.displayPanel = new JPanel(); // 숫자표시칸 관련 패널 
		this.keyPadPanel = new JPanel(); // 숫자패드 관련 패널 
		
		displayPanel.setLayout(new FlowLayout());
		keyPadPanel.setLayout(new GridLayout(0,4,5,5));
		
		this.textArea = new JTextField(11);
		textArea.setText("0"); 
		textArea.setHorizontalAlignment(JTextField.RIGHT);
		textArea.setFont(constant.font);
		
		add(textArea,BorderLayout.NORTH);
		
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
		setSignButtonFont(dot);
		setSignButtonFont(changingSign);
		setSignButtonFont(equal);
		setSignButtonFont(backSpace);

		// 연산 기호 이벤트 처리 
		plus.addActionListener(new OperatorListener());
		minus.addActionListener(new OperatorListener());
		multiply.addActionListener(new OperatorListener());
		divide.addActionListener(new OperatorListener());
		equal.addActionListener(new EqualListener());
		c.addActionListener(new ResetListener());
		ce.addActionListener(new ResetListener()); 
		dot.addActionListener(null);
		changingSign.addActionListener(new ChangingSignListener());
		backSpace.addActionListener(null);

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
		
		keyPadPanel.setLayout(new GridLayout(5,4));
		
		add(keyPadPanel,BorderLayout.CENTER);
		}		
	
	
	public void setButtonFont(JButton btn) {
		btn.setFont(constant.font);
	}
	
	public void setSignButtonFont(JButton btn) {
		btn.setFont(constant.signFont);
	}
	
	public void runOperation(String operator)
	{
		if(operator == "+") {sum += num;}
		else if(operator == "ㅡ") {sum -= num;}
		else if(operator == "X") {sum *= num;}
		else if(operator == "/") {sum /= num;}
	}

	public void reset() {
		isNewNumberStart  = true; 
		isFirstNumber = true;
		isEqualNext = false;
		isOperatorNext = false;
		lastedOperator = null;
		isChanging = false;
		
		num = 0; 
		sum = 0;
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
			
			// 입력한 숫자 저장 
			if(isFirstNumber) {sum = Integer.parseInt(textArea.getText());}
			else{ num = Integer.parseInt(textArea.getText());}

			// 연산 기호 다음 숫자일 떄 처리(계산해주는 과정) 
			
			isNewNumberStart = false;
			isEqualNext = false;
			isOperatorNext = false;
		}
	}
	
	// 연산 기호 이벤트 처리 
	private class OperatorListener implements ActionListener{
		public void actionPerformed(ActionEvent e ) {
			
			JButton operatorButton = (JButton)e.getSource();
			String operator = operatorButton.getText();
			
			if(lastedOperator  != null) {runOperation(lastedOperator);}

			lastedOperator = operator;	
			
			isOperatorNext = true;
			isChanging = false;
			isNewNumberStart  = true;
			isFirstNumber = false;
		}		
	}
	
	// 등호(=) 이벤트 처리 
	private class EqualListener implements ActionListener{
		public void actionPerformed(ActionEvent e)
		{
			if(!isOperatorNext)
			{
	
				if(isChanging)
				{
					sum *= -1;
					isEqualNext = true;
					runOperation(lastedOperator);
					textArea.setText(Integer.toString(sum));
				}
				
				else if(!isChanging)
				{
					isEqualNext = true;
					runOperation(lastedOperator);
					textArea.setText(Integer.toString(sum));
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

	private class ChangingSignListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e)
		{ 
			// 계산기에서 맨처음으로 입력할 떄 
			if(isNewNumberStart)
			{
				textArea.setText("");
				textArea.setText("-");
				isNewNumberStart = false;
				setChangingSign();
				return;
			}
	
			ShowChangeOperator(sum);
			setChangingSign();
		}
		
		public void setChangingSign() {
			if(!textArea.getText().equals("-")) {sum = Integer.parseInt(textArea.getText());}
			isChanging = true;
		}
	}
	
	// 부호 바뀌는 거 사용자에게 보여주는 함수 
	public void ShowChangeOperator(int number) {
		
		if(number > 0)
		{
			textArea.setText("");
			textArea.setText("-" + Integer.toString(number));
		}
		
		else if(number < 0)
		{
			textArea.setText("");
			textArea.setText(Integer.toString(number));
		}
	}
	
}



