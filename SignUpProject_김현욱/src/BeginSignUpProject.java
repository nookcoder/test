import java.awt.EventQueue;

import Controller.LoginController;
import Controller.SignUpController;
import model.MemberDataBase;
import view.*;
import view.SignUp;

public class BeginSignUpProject {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

		LoginView loginView = new LoginView();
		MemberDataBase data = new MemberDataBase();
		LoginController loginController = new LoginController(data,loginView);
//		EventQueue.invokeLater(new Runnable() {
//			public void run() {
//				try {
//					SignUp frame = new SignUp();
//					MemberDataBase member = new MemberDataBase();
//					SignUpController controller = new SignUpController(member, frame);
//					frame.setVisible(true);
//				} catch (Exception e) {
//					e.printStackTrace();
//				}
//			}
//		});
	}

}
