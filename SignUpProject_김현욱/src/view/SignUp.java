package view;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.AbstractBorder;
import javax.swing.border.EmptyBorder;

import model.Constants;

import javax.swing.JTextField;
import java.awt.*;
import javax.swing.JLabel;
import javax.swing.SpringLayout;
import java.awt.Font;
import java.awt.geom.Area;
import java.awt.geom.*;

import javax.swing.SwingConstants;
import javax.swing.*;

public class SignUp extends JFrame {

	private Constants constants = new Constants();
	private JPanel contentPane;
	private JTextField idField;
	private JTextField passwordField;
	private JTextField passwordCheckField;
	private JTextField nameField;
	private JTextField birthField;
	private JTextField phoneNumberField;
	private JTextField emailField;
	private JTextField addressField;
	
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

	public SignUp() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(400,600);
		setResizable(false);
		
		contentPane = new JPanel() {
			public void paintComponent(Graphics g)
			{
				Dimension dimension = getSize();
				Image background = constants.SIGNUP_BACKGROUND.getImage();
				g.drawImage(background, 0, 0, dimension.width,dimension.height,null);
				setOpaque(false);
				super.paintComponent(g);
			}
		};
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JLabel idLabel = new JLabel("아이디 :  ");
		idLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		idLabel.setFont(new Font("휴먼매직체", Font.BOLD, 14));
		idLabel.setBounds(31, 10, 71, 51);
		idLabel.setForeground(constants.YELLOW);
		contentPane.add(idLabel);
		
		JLabel passwordLabel = new JLabel("비밀번호 : ");
		passwordLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		passwordLabel.setFont(new Font("휴먼매직체", Font.BOLD, 15));
		passwordLabel.setBounds(31, 71, 71, 51);
		passwordLabel.setForeground(constants.YELLOW);
		contentPane.add(passwordLabel);
		
		JLabel passwordCheckLabel = new JLabel("비밀번호 확인 : ");
		passwordCheckLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		passwordCheckLabel.setFont(new Font("휴먼매직체", Font.BOLD, 15));
		passwordCheckLabel.setBounds(-1, 124, 103, 51);
		passwordCheckLabel.setForeground(constants.YELLOW);
		contentPane.add(passwordCheckLabel);
		
		JLabel nameLabel = new JLabel("이름 : ");
		nameLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		nameLabel.setFont(new Font("휴먼매직체", Font.BOLD, 15));
		nameLabel.setBounds(31, 185, 71, 51);
		nameLabel.setForeground(constants.YELLOW);
		contentPane.add(nameLabel);
		
		JLabel birthLabel = new JLabel("생년월일 : ");
		birthLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		birthLabel.setFont(new Font("휴먼매직체", Font.BOLD, 15));
		birthLabel.setBounds(31, 245, 71, 51);
		birthLabel.setForeground(constants.YELLOW);
		contentPane.add(birthLabel);
		
		JLabel phoneNumberLabel = new JLabel("전화번호 : ");
		phoneNumberLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		phoneNumberLabel.setFont(new Font("휴먼매직체", Font.BOLD, 15));
		phoneNumberLabel.setBounds(31, 312, 71, 51);
		phoneNumberLabel.setForeground(constants.YELLOW);
		contentPane.add(phoneNumberLabel);
		 
		JLabel emailLabel = new JLabel("이메일 : ");
		emailLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		emailLabel.setFont(new Font("휴먼매직체", Font.BOLD, 15));
		emailLabel.setForeground(constants.YELLOW);
		emailLabel.setBounds(43, 373, 59, 51);
		contentPane.add(emailLabel);
		
		JLabel addressLabel = new JLabel("주소 : ");
		addressLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		addressLabel.setFont(new Font("휴먼매직체", Font.BOLD, 15));
		addressLabel.setBounds(43, 434, 59, 53);
		addressLabel.setForeground(constants.YELLOW);
		contentPane.add(addressLabel);
		
		idField = new JTextField() {
			@Override 
			protected void paintComponent(Graphics g) {
				if (!isOpaque() && getBorder() instanceof RoundedCornerBorder) {
					Graphics2D g2 = (Graphics2D) g.create();
					g2.setPaint(getBackground());
					g2.fill(((RoundedCornerBorder) getBorder()).getBorderShape(
							0, 0, getWidth() - 1, getHeight() - 1));
					g2.dispose();
				}
				super.paintComponent(g);
			}
			@Override 
			public void updateUI() {
				super.updateUI();
				setOpaque(false);
				setBorder(new RoundedCornerBorder());
			}
		};
		idField .setBounds(114, 18, 225, 36);
		idField.setColumns(10);
		idField.setBackground(constants.LIGHE_BLUE);
		contentPane.add(idField);
		
		passwordField = new JTextField() {
			@Override 
			protected void paintComponent(Graphics g) {
				if (!isOpaque() && getBorder() instanceof RoundedCornerBorder) {
					Graphics2D g2 = (Graphics2D) g.create();
					g2.setPaint(getBackground());
					g2.fill(((RoundedCornerBorder) getBorder()).getBorderShape(
							0, 0, getWidth() - 1, getHeight() - 1));
					g2.dispose();
				}
				super.paintComponent(g);
			}
			@Override 
			public void updateUI() {
				super.updateUI();
				setOpaque(false);
				setBorder(new RoundedCornerBorder());
			}
		};
		passwordField.setColumns(10);
		passwordField.setBounds(114, 79, 225, 36);
		passwordField.setBackground(constants.LIGHE_BLUE);
		contentPane.add(passwordField);
		
		passwordCheckField = new JTextField() {
			@Override 
			protected void paintComponent(Graphics g) {
				if (!isOpaque() && getBorder() instanceof RoundedCornerBorder) {
					Graphics2D g2 = (Graphics2D) g.create();
					g2.setPaint(getBackground());
					g2.fill(((RoundedCornerBorder) getBorder()).getBorderShape(
							0, 0, getWidth() - 1, getHeight() - 1));
					g2.dispose();
				}
				super.paintComponent(g);
			}
			@Override 
			public void updateUI() {
				super.updateUI();
				setOpaque(false);
				setBorder(new RoundedCornerBorder());
			}
		};
		passwordCheckField.setColumns(10);
		passwordCheckField.setBounds(114, 132, 225, 36);
		passwordCheckField.setBackground(constants.LIGHE_BLUE);
		contentPane.add(passwordCheckField);
		
		nameField = new JTextField() {
			@Override 
			protected void paintComponent(Graphics g) {
				if (!isOpaque() && getBorder() instanceof RoundedCornerBorder) {
					Graphics2D g2 = (Graphics2D) g.create();
					g2.setPaint(getBackground());
					g2.fill(((RoundedCornerBorder) getBorder()).getBorderShape(
							0, 0, getWidth() - 1, getHeight() - 1));
					g2.dispose();
				}
				super.paintComponent(g);
			}
			@Override 
			public void updateUI() {
				super.updateUI();
				setOpaque(false);
				setBorder(new RoundedCornerBorder());
			}
		};
		nameField.setColumns(10);
		nameField.setBounds(114, 193, 225, 36);
		nameField.setBackground(constants.LIGHE_BLUE);
		contentPane.add(nameField);
		
		birthField = new JTextField() {
			@Override 
			protected void paintComponent(Graphics g) {
				if (!isOpaque() && getBorder() instanceof RoundedCornerBorder) {
					Graphics2D g2 = (Graphics2D) g.create();
					g2.setPaint(getBackground());
					g2.fill(((RoundedCornerBorder) getBorder()).getBorderShape(
							0, 0, getWidth() - 1, getHeight() - 1));
					g2.dispose();
				}
				super.paintComponent(g);
			}
			@Override 
			public void updateUI() {
				super.updateUI();
				setOpaque(false);
				setBorder(new RoundedCornerBorder());
			}
		};
		birthField.setColumns(10);
		birthField.setBounds(114, 253, 225, 36);
		birthField.setBackground(constants.LIGHE_BLUE);
		contentPane.add(birthField);
		
		phoneNumberField = new JTextField() {
			@Override 
			protected void paintComponent(Graphics g) {
				if (!isOpaque() && getBorder() instanceof RoundedCornerBorder) {
					Graphics2D g2 = (Graphics2D) g.create();
					g2.setPaint(getBackground());
					g2.fill(((RoundedCornerBorder) getBorder()).getBorderShape(
							0, 0, getWidth() - 1, getHeight() - 1));
					g2.dispose();
				}
				super.paintComponent(g);
			}
			@Override 
			public void updateUI() {
				super.updateUI();
				setOpaque(false);
				setBorder(new RoundedCornerBorder());
			}
		};
		phoneNumberField.setColumns(10);
		phoneNumberField.setBounds(114, 320, 225, 36);
		phoneNumberField.setBackground(constants.LIGHE_BLUE);
		contentPane.add(phoneNumberField);
		
		emailField = new JTextField() {
			@Override 
			protected void paintComponent(Graphics g) {
				if (!isOpaque() && getBorder() instanceof RoundedCornerBorder) {
					Graphics2D g2 = (Graphics2D) g.create();
					g2.setPaint(getBackground());
					g2.fill(((RoundedCornerBorder) getBorder()).getBorderShape(
							0, 0, getWidth() - 1, getHeight() - 1));
					g2.dispose();
				}
				super.paintComponent(g);
			}
			@Override 
			public void updateUI() {
				super.updateUI();
				setOpaque(false);
				setBorder(new RoundedCornerBorder());
			}
		};
		emailField.setColumns(10);
		emailField.setBounds(114, 381, 225, 36);
		emailField.setBackground(constants.LIGHE_BLUE);
		contentPane.add(emailField);
		
		addressField = new JTextField() {
			@Override 
			protected void paintComponent(Graphics g) {
				if (!isOpaque() && getBorder() instanceof RoundedCornerBorder) {
					Graphics2D g2 = (Graphics2D) g.create();
					g2.setPaint(getBackground());
					g2.fill(((RoundedCornerBorder) getBorder()).getBorderShape(
							0, 0, getWidth() - 1, getHeight() - 1));
					g2.dispose();
				}
				super.paintComponent(g);
			}
			@Override 
			public void updateUI() {
				super.updateUI();
				setOpaque(false);
				setBorder(new RoundedCornerBorder());
			}
		};
		addressField.setColumns(10);
		addressField.setBounds(114, 443, 225, 36);
		addressField.setBackground(constants.LIGHE_BLUE);
		contentPane.add(addressField);
	}
	
	public class RoundedCornerBorder extends AbstractBorder {
		private Color ALPHA_ZERO = new Color(0x0, true);
		@Override 
		public void paintBorder(Component c, Graphics g, int x, int y, int width, int height) {
			Graphics2D g2 = (Graphics2D) g.create();
			g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
			Shape border = getBorderShape(x, y, width - 1, height - 1);
			g2.setPaint(ALPHA_ZERO);
			Area corner = new Area(new Rectangle2D.Double(x, y, width, height));
			corner.subtract(new Area(border));
			g2.fill(corner);
			g2.setPaint(Color.GRAY);
			g2.draw(border);
			g2.dispose();
		}
		public Shape getBorderShape(int x, int y, int w, int h) {
			int r = h; //h / 2;
			return new RoundRectangle2D.Double(x, y, w, h, r, r);
		}
		@Override public Insets getBorderInsets(Component c) {
			return new Insets(4, 8, 4, 8);
		}
		@Override public Insets getBorderInsets(Component c, Insets insets) {
			insets.set(4, 8, 4, 8);
			return insets;
		}
	}
}
