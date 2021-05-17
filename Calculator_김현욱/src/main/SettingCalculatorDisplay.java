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
	
	public String lastedOperator;
	private int num;
	private int sum;
	static boolean isNewNumberStart  = true; 
	static boolean isContinue = false;
	static boolean isEqualNext = false;
	static boolean isFirstNumber = true;
	
	public SettingCalculatorDisplay() {
		this.constant = new Constants();
		this.num = 0; 
		this.sum = 0;
		
		this.displayPanel = new JPanel(); 
		this.keyPadPanel = new JPanel();
		
		displayPanel.setLayout(new FlowLayout());
		keyPadPanel.setLayout(new GridLayout(0,4,5,5));
		
		this.textArea = new JTextField(11);
		textArea.setText("0"); 
		textArea.setHorizontalAlignment(JTextField.RIGHT);
		textArea.setFont(constant.font);
		
		add(textArea,BorderLayout.NORTH);
		
		this.keyPadPanel = new JPanel(); 
		this.numberButton = new JButton[10];
		
		for(int number = 0; number<10;number++)
		{
			numberButton[number] = new JButton(Integer.toString(number));
			setButtonFont(numberButton[number]);
			
			numberButton[number].addActionListener(new NumberButtonListener());
		}
		
		this.plus = new JButton("+");
		this.minus = new JButton("ㅡ");
		this.multiply = new JButton("X");
		this.divide = new JButton("%");
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
		c.addActionListener(null);
		ce.addActionListener(null);
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

	private class NumberButtonListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e){
			JButton numberButton = (JButton)e.getSource();
			String number = numberButton.getText();
			String result = textArea.getText(); 
			if(isNewNumberStart ||result.equals("0")||isEqualNext)
			{
				textArea.setText("");
				textArea.setText(number);
			}			
			
			
			else {textArea.setText(result + number);}
			
			num = Integer.parseInt(textArea.getText());
			
			isNewNumberStart = false;
			isEqualNext = false;
		}
	}
	
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
				
				else 
				{
					if(operator == "+") {sum += num;}
					else if(operator == "ㅡ") {sum -= num;}
					else if(operator == "X") {sum *= num;}
					else if(operator == "%") {sum /= num;}
				}
				
				lastedOperator = operator;
				isNewNumberStart  = true;
		}
		
	}
	
	private class EqualListener implements ActionListener{
		public void actionPerformed(ActionEvent e)
		{
			RunOperation(lastedOperator);
			textArea.setText(Integer.toString(sum));
		}
		
		public void RunOperation(String operator)
		{
			if(operator == "+") {sum += num;}
			else if(operator == "ㅡ") {sum -= num;}
			else if(operator == "X") {sum *= num;}
			else if(operator == "%") {sum /= num;}
			isEqualNext = true;
		}
		
	}
}



