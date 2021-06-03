package view;


import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

import javax.swing.*;
import javax.swing.border.EmptyBorder;
import javax.swing.text.AttributeSet;
import javax.swing.text.BadLocationException;
import javax.swing.text.PlainDocument;

import model.*;

public class RevisingInfoView extends JFrame{

	private Constants constants = new Constants();
	private JPanel contentPane;
	public JTextField idField;
	public JTextField nameField;
	public JTextField birthField;
	public JTextField phoneNumberField;
	public JTextField emailField;
	public JTextField addressField;
	public JButton cansleButton;
	public JButton okayButton;

	public JLabel idExplanation;
	public JLabel passwordExplanation;
	public JLabel passwordCheckExplanation;
	public JLabel nameExplanation;
	public JLabel birthExplanation;
	public JLabel phoneNumberExplanation;
	public JLabel emailExplanation;
	public JLabel addressExplanation;
	public JTextField textField;


	public RevisingInfoView() {

		setUndecorated(true);
		setSize(400,450);
		setResizable(false);
		setLocationRelativeTo(null);

		contentPane = new JPanel();
		contentPane.setBackground(constants.LIGHE_BLUE);
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);

		JPanel userInfoPanel = new JPanel();
		userInfoPanel.setBounds(12, 34, 376, 315);
		userInfoPanel.setLayout(null);
		userInfoPanel.setBackground(constants.MIDDLE_BLUE);

		JLabel nameLabel = new JLabel("이름");
		nameExplanation = new JLabel();
		nameExplanation.setBounds(105, 81, 234, 23);
		nameExplanation.setFont(constants.EXPLANINATION_FONT);
		nameLabel.setHorizontalAlignment(SwingConstants.CENTER);
		nameLabel.setBounds(12, 60, 88, 23);
		decorateTextBox(nameLabel);
		userInfoPanel.add(nameLabel);
		userInfoPanel.add(nameExplanation);

		JLabel birthLabel = new JLabel("생년월일");
		birthExplanation = new JLabel();
		birthExplanation.setLocation(105, 131);
		birthExplanation.setSize(234, 30);
		birthExplanation.setFont(constants.EXPLANINATION_FONT);
		birthLabel.setHorizontalAlignment(SwingConstants.CENTER);
		birthLabel.setBounds(12, 110, 88, 23);
		decorateTextBox(birthLabel);
		userInfoPanel.add(birthLabel);
		userInfoPanel.add(birthExplanation);

		JLabel phoneNumberLabel = new JLabel("전화번호");
		phoneNumberExplanation = new JLabel();
		phoneNumberExplanation.setLocation(105, 180);
		phoneNumberExplanation.setFont(constants.EXPLANINATION_FONT);
		phoneNumberExplanation.setSize(234, 30);
		phoneNumberLabel.setHorizontalAlignment(SwingConstants.CENTER);
		phoneNumberLabel.setBounds(12, 160, 88, 23);
		decorateTextBox(phoneNumberLabel);
		userInfoPanel.add(phoneNumberLabel);
		userInfoPanel.add(phoneNumberExplanation);

		JLabel emailLabel = new JLabel("이메일");
		emailExplanation= new JLabel();
		emailExplanation.setLocation(105, 182);
		emailExplanation.setSize(234, 30);
		emailExplanation.setFont(constants.EXPLANINATION_FONT);
		emailLabel.setHorizontalAlignment(SwingConstants.CENTER);
		emailLabel.setBounds(12, 210, 88, 23);
		decorateTextBox(emailLabel);
		userInfoPanel.add(emailLabel);
		userInfoPanel.add(emailExplanation);

		JLabel addressLabel = new JLabel("주소");
		addressExplanation= new JLabel("");
		addressExplanation.setLocation(105, 290);
		addressExplanation.setSize(234, 24);
		addressExplanation.setFont(constants.EXPLANINATION_FONT);
		addressLabel.setHorizontalAlignment(SwingConstants.CENTER);
		addressLabel.setBounds(12, 260, 88, 23);
		decorateTextBox(addressLabel);
		userInfoPanel.add(addressLabel);
		userInfoPanel.add(addressExplanation);

		nameField = new JTextField();
		nameField.setColumns(10);
		nameField.setDocument(new JTextFieldLimit(4));
		nameField.setBounds(105, 60, 234, 23);
		nameField.setFont(constants.SIGNUP_FONT);
		nameField.setEditable(false);
		userInfoPanel.add(nameField);

		birthField = new JTextField();
		birthField.setDocument(new JTextFieldLimit(6));
		birthField.setColumns(10);
		birthField.setBounds(105, 110, 234, 23);
		birthField.setFont(constants.SIGNUP_FONT);
		birthField.setEditable(false);
		userInfoPanel.add(birthField);

		emailField = new JTextField();
		emailField.setColumns(10);
		emailField.setBounds(105, 210, 234, 23);
		emailField.setFont(constants.SIGNUP_FONT);
		emailField.setDocument(new JTextFieldLimit(26));
		userInfoPanel.add(emailField);

		addressField = new JTextField();
		addressField.setColumns(10);
		addressField.setBounds(105, 260, 234, 23);
		addressField.setFont(constants.SIGNUP_FONT);
		addressField.setDocument(new JTextFieldLimit(26));
		userInfoPanel.add(addressField);

		contentPane.add(userInfoPanel);

		textField = new JTextField();
		textField.setBounds(105, 160, 234, 23);
		userInfoPanel.add(textField);
		textField.setColumns(10);

		JLabel idLabel = new JLabel("게임아이디");
		idLabel.setBounds(12, 10, 88, 23);
		userInfoPanel.add(idLabel);
		idLabel.setHorizontalAlignment(SwingConstants.CENTER);

		decorateTextBox(idLabel);

		idField = new JTextField();
		idField.setBounds(105, 10, 234, 23);
		userInfoPanel.add(idField);
		idField.setColumns(10);
		idField.setEditable(false);
		idField.setDocument(new JTextFieldLimit(12));
		idField.setFont(constants.EXPLANINATION_FONT);

		okayButton = new JButton("확인");
		okayButton.setBounds(70, 395, 90, 30);
		contentPane.add(okayButton);
		constants.decorateButton(okayButton);

		cansleButton = new JButton("취소");
		cansleButton.setLocation(208, 395);
		cansleButton.addActionListener(new CansleButtonListener());
		cansleButton.setSize(90, 30);
		
		contentPane.add(cansleButton);
		constants.decorateButton(cansleButton);
	
		setVisible(true);
	}	
	
	public void decorateIdCheckButton(JButton btn)
	{

		btn.setBackground(constants.LIGHE_BLUE);
		btn.setForeground(Color.WHITE);
		btn.setFont(constants.LOGIN_FONT);
		btn.setBorder(BorderFactory.createCompoundBorder(
				BorderFactory.createRaisedBevelBorder(),
				BorderFactory.createEmptyBorder(2, 20, 2, 20)
				));
		btn.setMargin(new Insets(5,15,5,15));
		btn.setFocusPainted(false);
	}

	public void decorateTextBox(JLabel label) {
		label.setBackground(constants.BLUE);
		label.setForeground(constants.LIGHE_BLUE);
		label.setFont(constants.LOGIN_FONT);
		label.setHorizontalAlignment(SwingConstants.CENTER);
		label.setOpaque(true);
		label.setBorder(BorderFactory.createEmptyBorder(2, 10, 2, 10));
	}


	public class JTextFieldLimit extends PlainDocument {
		private int limit;

		JTextFieldLimit(int limit) {
			super();
			this.limit = limit;
		}

		public void insertString( int offset, String  str, AttributeSet attr ) throws BadLocationException {
			if (str == null) return;

			if ((getLength() + str.length()) <= limit) {
				super.insertString(offset, str, attr);
			}
		}
	}
	
	private class CansleButtonListener implements ActionListener{

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			setVisible(false);
		}
		
	}
}















