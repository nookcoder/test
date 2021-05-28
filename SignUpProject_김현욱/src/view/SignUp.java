package view;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JTextField;
import java.awt.*;
import javax.swing.JLabel;
import javax.swing.SpringLayout;
import java.awt.Font;
import javax.swing.SwingConstants;

public class SignUp extends JFrame {

	private JPanel contentPane;
	private JTextField idField;
	private JTextField passwordField;
	private JTextField passwordCheckField;
	private JTextField nameField;
	private JTextField birthField;
	private JTextField phoneNumberField;
	private JTextField emailField;
	private JTextField addressField;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					SignUp frame = new SignUp();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public SignUp() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(400,600);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JLabel idLabel = new JLabel("아이디 : ");
		idLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		idLabel.setFont(new Font("SansSerif", Font.BOLD, 12));
		idLabel.setBounds(31, 10, 71, 51);
		contentPane.add(idLabel);
		
		JLabel passwordLabel = new JLabel("비밀번호 : ");
		passwordLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		passwordLabel.setFont(new Font("SansSerif", Font.BOLD, 12));
		passwordLabel.setBounds(31, 71, 71, 51);
		contentPane.add(passwordLabel);
		
		JLabel passwordCheckLabel = new JLabel("비밀번호 확인 : ");
		passwordCheckLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		passwordCheckLabel.setFont(new Font("SansSerif", Font.BOLD, 12));
		passwordCheckLabel.setBounds(-1, 124, 103, 51);
		contentPane.add(passwordCheckLabel);
		
		JLabel nameLabel = new JLabel("이름 : ");
		nameLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		nameLabel.setFont(new Font("SansSerif", Font.BOLD, 12));
		nameLabel.setBounds(31, 185, 71, 51);
		contentPane.add(nameLabel);
		
		JLabel birthLabel = new JLabel("생년월일 : ");
		birthLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		birthLabel.setFont(new Font("SansSerif", Font.BOLD, 12));
		birthLabel.setBounds(31, 245, 71, 51);
		contentPane.add(birthLabel);
		
		JLabel phoneNumberLabel = new JLabel("전화번호 : ");
		phoneNumberLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		phoneNumberLabel.setFont(new Font("SansSerif", Font.BOLD, 12));
		phoneNumberLabel.setBounds(31, 312, 71, 51);
		contentPane.add(phoneNumberLabel);
		 
		JLabel emailLabel = new JLabel("이메일 : ");
		emailLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		emailLabel.setFont(new Font("SansSerif", Font.BOLD, 12));
		emailLabel.setBounds(43, 373, 59, 51);
		contentPane.add(emailLabel);
		
		JLabel addressLabel = new JLabel("주소 : ");
		addressLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		addressLabel.setFont(new Font("SansSerif", Font.BOLD, 12));
		addressLabel.setBounds(43, 434, 59, 53);
		contentPane.add(addressLabel);
		
		idField = new JTextField();
		idField .setBounds(114, 18, 225, 36);
		contentPane.add(idField);
		idField.setColumns(10);
		
		passwordField = new JTextField();
		passwordField.setColumns(10);
		passwordField.setBounds(114, 79, 225, 36);
		contentPane.add(passwordField);
		
		passwordCheckField = new JTextField();
		passwordCheckField.setColumns(10);
		passwordCheckField.setBounds(114, 132, 225, 36);
		contentPane.add(passwordCheckField);
		
		nameField = new JTextField();
		nameField.setColumns(10);
		nameField.setBounds(114, 193, 225, 36);
		contentPane.add(nameField);
		
		birthField = new JTextField();
		birthField.setColumns(10);
		birthField.setBounds(114, 253, 225, 36);
		contentPane.add(birthField);
		
		phoneNumberField = new JTextField();
		phoneNumberField.setColumns(10);
		phoneNumberField.setBounds(114, 320, 225, 36);
		contentPane.add(phoneNumberField);
		
		emailField = new JTextField();
		emailField.setColumns(10);
		emailField.setBounds(114, 381, 225, 36);
		contentPane.add(emailField);
		
		addressField = new JTextField();
		addressField.setColumns(10);
		addressField.setBounds(114, 443, 225, 36);
		contentPane.add(addressField);
		

	}
}
