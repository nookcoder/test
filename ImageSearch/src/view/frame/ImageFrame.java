package view.frame;

import javax.swing.*;
import java.awt.*;

public class ImageFrame extends JFrame {
    private JComponent imagePanel;

    public ImageFrame(int width, int height, Image image){
        imagePanel = new JComponent() {
            @Override
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(image,0,0,this);
            }
        };
        setSize(width,height);
    }

    public void open(){
        setContentPane(imagePanel);
        setResizable(true);
        setVisible(true);
    }
}
