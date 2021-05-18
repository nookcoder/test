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
	
	public String lastedOperator; // 가장 최근에 입력된 사칙연산 기호 
	private int num; // 입력된 숫자 
	private int sum; // 출력될 계산 결과 값
	private boolean isNewNumberStart  = true; // 새로운 숫자가 입력되는 지 판단
	private boolean isEqualNext = false; // = 를 누른 후 다음 이벤트인지 판단
	private boolean isFirstNumber = true; // 계산 과정에서 첫번째 입력 숫자인지 확인 
	
	public SettingCalculatorDisplay() {
		this.constant = new Constants();
		
		// 계산과정에서 쓰일 변수들 초기화 
		this.num = 0; 
		this.sum = 0;
		this.lastedOperator = null;
		this.isNewNumberStart = true;
		this.isFirstNumber = true;
		this.isEqualNext = false;
		
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
		changingSign.addActionListener(null);
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

	// 숫자 키 입력 시 이벤트 처리 
	private class NumberButtonListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e){
			JButton numberButton = (JButton)e.getSource();
			String number = numberButton.getText();
			String result = textArea.getText(); 
			
			// 새로운 숫자 입력시 기존 쓰여져있던 숫자 지우기 
			if(isNewNumberStart ||result.equals("0")||isEqualNext)
			{
				textArea.setText("");
				textArea.setText(number);
			}			
			
			
			// 연속으로 숫자 입력 시 
			else {textArea.setText(result + number);}
			
			// 입력한 숫자 저장 
			num = Integer.parseInt(textArea.getText());
			
			// 연산 기호 다음 숫자일 떄 처리(계산해주는 과정) 
			if(lastedOperator != null)
			{
				RunOperator(lastedOperator);
			}
			
			isNewNumberStart = false;
			isEqualNext = false;
		}
		
		// 계산하는 함수 
		public void RunOperator(String lastedOperator)
		{
			if(lastedOperator == "+") {sum += num;}
			else if(lastedOperator == "ㅡ") {sum -= num;}
			else if(lastedOperator == "X") {sum *= num;}
			else if(lastedOperator == "/") {sum /= num;}
		}
	}
	
	// 연산 기호 이벤트 처리 
	private class OperatorListener implements ActionListener{
		public void actionPerformed(ActionEvent e ) {
			
			JButton operatorButton = (JButton)e.getSource();
			String operator = operatorButton.getText();

			RunOperator(operator);
		}
		
		public void RunOperator(String operator) 
		{
			
				if(isFirstNumber)
				{
					sum = num;
					isFirstNumber = false;
				}
				
				lastedOperator = operator;
				isNewNumberStart  = true;
		}
		
	}
	
	// 등호(=) 이벤트 처리 
	private class EqualListener implements ActionListener{
		public void actionPerformed(ActionEvent e)
		{
			// 등호를 연속으로 입력했을 떄 
			if(isEqualNext)
			{
				RunOperation(lastedOperator);
			}
			
			isEqualNext = true;
			textArea.setText(Integer.toString(sum));
		}
		
		public void RunOperation(String operator)
		{
			if(operator == "+") {sum += num;}
			else if(operator == "ㅡ") {sum -= num;}
			else if(operator == "X") {sum *= num;}
			else if(operator == "/") {sum /= num;}
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
				num = 0; 
				isNewNumberStart  = true; 
				isEqualNext = false;
				isFirstNumber = true;
				sum = 0;
				textArea.setText("0");
			}
			
			// 등호 다음 ce 입력 시 초기화, 계산과정중 ce입력시 숫자만 초기화 
			else if (resetButton.getText() == "CE")
			{
				textArea.setText("0");
				if(isEqualNext) {
					isNewNumberStart  = true; 
					isEqualNext = false;
					isFirstNumber = true;
					lastedOperator = null;
					num = 0; 
					sum = 0;
				}
			}
		}
	}
}



