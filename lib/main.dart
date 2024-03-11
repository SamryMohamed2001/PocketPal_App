import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:imagine_cup_ui/colors.dart';
// import 'package:firebase_core/firebase_core.dart';
// import 'package:cloud_firestore/cloud_firestore.dart';

void main() => runApp(
    MaterialApp(
      debugShowCheckedModeBanner: false,
      home: Socar(),
    )
);


class Socar extends StatelessWidget {
  @override
  Widget build(BuildContext ctxt) {
    return new MaterialApp(
      home: new FirstScreen(),
    );
  }
}

class FirstScreen extends StatelessWidget{
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        padding: EdgeInsets.symmetric(vertical: 70),
        width: double.infinity,
        decoration: BoxDecoration(
            gradient: LinearGradient(
                begin: Alignment.topCenter,
                colors: [
                  Colors.blue,
                  Colors.white
                ]
            )
        ),
        child: Column(
          children: <Widget>[
            SizedBox(height: 40,),
            Padding(
              padding: EdgeInsets.all(20),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: <Widget>[
                  Text("Sign In", style: TextStyle(color: Colors.black, fontSize: 40, fontFamily: 'Poppins', fontWeight: FontWeight.bold),),
                  SizedBox(height: 5,),
                  Text("Welcome Back!", style: TextStyle(color: Colors.black, fontSize: 18, fontFamily: 'Poppins'),),
                ],
              ),
            ),
            SizedBox(height: 20,),
            Expanded(
              child: Container(
                decoration: BoxDecoration(
                  color:Colors.white,
                  borderRadius: BorderRadius.only(topLeft: Radius.circular(60), topRight: Radius.circular(60),),
                ),
                child: Padding(
                  padding: EdgeInsets.all(30),
                  child: Column(
                      children: <Widget>[
                        SizedBox(height:60,),
                        Container(
                          padding: EdgeInsets.all(10),
                          decoration: BoxDecoration(
                              color: Colors.white,
                              borderRadius: BorderRadius.circular(10),
                              boxShadow: [BoxShadow(
                                  color: Color.fromRGBO(225, 95, 27, .3),
                                  blurRadius: 30,
                                  offset: Offset(0, 10)
                              )]
                          ),
                          child: Column(
                            children: <Widget> [
                              Container(
                                decoration: BoxDecoration(
                                  border: Border(bottom: BorderSide(color: Colors.grey)),
                                ),
                                child: TextField(
                                  decoration: InputDecoration(
                                    hintText: "Email or Phone Number",
                                    hintStyle: TextStyle(color: Colors.grey, fontFamily: 'Poppins'),
                                    border: InputBorder.none,
                                  ),
                                ),
                              ),
                              Container(
                                decoration: BoxDecoration(
                                  border: Border(bottom: BorderSide(color: Colors.grey)),
                                ),
                                child: TextField(
                                  decoration: InputDecoration(
                                    hintText: "Password",
                                    hintStyle: TextStyle(color: Colors.grey, fontFamily: 'Poppins'),
                                    border: InputBorder.none,
                                  ),
                                ),
                              ),
                            ],
                          ),
                        ),
                        SizedBox(height: 40,),
                        Text("Forgot Password?", style: TextStyle(color: Colors.black, fontFamily: 'Poppins'),),
                        SizedBox(height: 40,),
                        Expanded(
                          child: InkWell(
                            onTap: () {
                              Navigator.push(
                                context,
                                MaterialPageRoute(builder: (context) => HomePage()),
                              );
                            },
                            child: Container(
                              height: 50,
                              margin: EdgeInsets.symmetric(horizontal: 40),
                              decoration: BoxDecoration(
                                borderRadius: BorderRadius.circular(50),
                                color: Colors.blue,
                              ),
                              child: Center(
                                child: Text("Sign In", style: TextStyle(color: Colors.white, fontSize: 16, fontFamily: 'Poppins', fontWeight: FontWeight.bold),),
                              ),
                            ),
                          ),
                        ),
                        SizedBox(height: 40,),
                        Text("OR", style: TextStyle(color: Colors.blueGrey, fontFamily: 'Poppins', fontWeight: FontWeight.bold, fontSize: 20),),
                        SizedBox(height: 30,),
                        Row(
                            children: <Widget>[
                              Expanded(
                                child: InkWell(
                                  onTap: () {
                                    Navigator.push(
                                      context,
                                      MaterialPageRoute(builder: (context) => SecondScreen()),
                                    );
                                  },
                                  child: Container(
                                    height: 50,
                                    margin: EdgeInsets.symmetric(horizontal: 40),
                                    decoration: BoxDecoration(
                                      borderRadius: BorderRadius.circular(50),
                                      color: Colors.orange,
                                    ),
                                    child: Center(
                                      child: Text("Sign Up", style: TextStyle(color: Colors.white, fontSize: 16, fontFamily: 'Poppins', fontWeight: FontWeight.bold),),
                                    ),
                                  ),

                                ),
                              ),
                            ]
                        ),
                      ]
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}

class SecondScreen extends StatelessWidget {
  @override
  Widget build (BuildContext ctxt) {
    return new Scaffold(
        appBar: AppBar(),
        body: SingleChildScrollView(
            child: Padding(
                padding: const EdgeInsets.all(50),
                child: Column(
                    children: [
                      Text("Let's Create your account", style: TextStyle(fontFamily: "Poppins", fontWeight: FontWeight.bold, fontSize: 35),),
                      SizedBox(height: 50,),
                      Form(child: Column(
                          children: [
                            Row(
                              children: [
                                Expanded(
                                  child: TextFormField(
                                    expands: false,
                                    decoration: const InputDecoration(
                                      labelText: "First Name",
                                    ),
                                  ),
                                ),
                                SizedBox(width: 30),
                                Expanded(
                                  child: TextFormField(
                                    expands: false,
                                    decoration: const InputDecoration(
                                      labelText: "Last Name",
                                    ),
                                  ),
                                ),
                              ],
                            ),
                            SizedBox(height: 10,),
                            TextFormField(
                              expands: false,
                              decoration: const InputDecoration(
                                labelText: "Username",
                              ),
                            ),
                            SizedBox(height: 10,),
                            TextFormField(
                              expands: false,
                              decoration: const InputDecoration(
                                labelText: "E-Mail",
                              ),
                            ),
                            SizedBox(height: 10,),
                            TextFormField(
                              expands: false,
                              decoration: const InputDecoration(
                                labelText: "Mobile Number",
                              ),
                            ),
                            SizedBox(height: 10,),
                            TextFormField(
                              expands: false,
                              decoration: const InputDecoration(
                                labelText: "Password",
                              ),
                            ),
                            SizedBox(height: 20,),
                            Row(
                              children: [
                                SizedBox(width: 24, height: 40,
                                    child: Checkbox(value: false, onChanged: (value){})),
                                SizedBox(width: 10),
                                Text.rich(TextSpan(
                                  children: [
                                    TextSpan(text: "I agree to the terms and conditions"),
                                  ],
                                ),
                                )
                              ],
                            ),
                            SizedBox(height: 20,),
                            InkWell(
                              onTap: () {
                                Navigator.push(
                                  ctxt,
                                  MaterialPageRoute(builder: (context) => FirstScreen()),
                                );
                              },
                              child: Container(
                                height: 50,
                                margin: EdgeInsets.symmetric(horizontal: 50),
                                decoration: BoxDecoration(
                                  borderRadius: BorderRadius.circular(50),
                                  color: Colors.blue,
                                ),
                                child: Center(
                                  child: Text("Sign Up", style: TextStyle(color: Colors.white, fontSize: 16, fontFamily: 'Poppins', fontWeight: FontWeight.bold),),
                                ),
                              ),
                            ),
                          ]
                      ))
                    ]
                )
            )
        )
    );
  }
}

class HomePage extends StatelessWidget {
  @override
  Widget build(BuildContext ctxt) {
    return Scaffold(
      body: ListView(
        padding: EdgeInsets.zero,
        children: [
          Container(
            decoration: BoxDecoration(
              color: Colors.blue,
              borderRadius: BorderRadius.only(
                bottomRight: Radius.circular(50),
              ),
            ),
            child: Column(
              children: [
                const SizedBox(height: 50,),
                ListTile(
                  contentPadding: EdgeInsets.symmetric(horizontal: 30),
                  title: Text(
                    "Hi John",
                    style: TextStyle(
                      fontFamily: "Poppins",
                      fontSize: 30,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  subtitle: Text(
                    "Hope you are doing well",
                    style: TextStyle(
                      fontFamily: "Poppins",
                      fontSize: 15,
                    ),
                  ),
                  trailing: CircleAvatar(
                    radius: 30,
                    // Placeholder for user image
                    // backgroundImage: AssetImage('assets/user_image.jpg'),
                  ),
                ),
                SizedBox(height: 50,),
              ],
            ),
          ),
          Container(
            color: Colors.transparent,
            child: Container(
              padding: EdgeInsets.symmetric(horizontal: 30),
              decoration: BoxDecoration(
                color: Colors.transparent,
                borderRadius: BorderRadius.only(
                  bottomLeft: Radius.circular(100),
                  topRight: Radius.circular(100),
                ),
              ),
              child: GridView.count(
                shrinkWrap: true,
                crossAxisCount: 2,
                children: [
                  InkWell(
                    onTap: () {
                      Navigator.push(
                        ctxt,
                        MaterialPageRoute(builder: (context) => ProfilePage()),
                      );
                    },
                    child: itemDashboard("Profile", CupertinoIcons.person, Colors.black),
                  ),
                  InkWell(
                    onTap: () {
                      Navigator.push(
                        ctxt,
                        MaterialPageRoute(builder: (context) => ProfilePage()),
                      );
                    },
                    child: itemDashboard("AI Chat", CupertinoIcons.play_rectangle, Colors.black),
                  ),
                  InkWell(
                    onTap: () {
                      Navigator.push(
                        ctxt,
                        MaterialPageRoute(builder: (context) => ARChatPage()),
                      );
                    },
                    child: itemDashboard("AR Chat", CupertinoIcons.person_2, Colors.white),
                  ),
                  InkWell(
                    onTap: () {
                      // Navigate to settings page
                      Navigator.push(
                        ctxt,
                        MaterialPageRoute(builder: (context) => SettingsPage()),
                      );
                    },
                    child: itemDashboard("Settings", Icons.settings, Colors.grey), // Add settings button
                  ),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }

  Widget itemDashboard(String title, IconData iconData, Color background) => Container(
    decoration: BoxDecoration(
      color: Colors.white,
      borderRadius: BorderRadius.circular(30),
      boxShadow: [
        BoxShadow(
          offset: const Offset(0, 5),
          color: Colors.blue,
          spreadRadius: 2,
          blurRadius: 5,
        ),
      ],
    ),
    child: Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Container(
          decoration: BoxDecoration(
            color: background,
            shape: BoxShape.circle,
          ),
          child: Icon(iconData, color: Colors.white),
        ),
        const SizedBox(height: 8,),
        Text(
          title,
          style: TextStyle(fontFamily: "Poppins", fontSize: 10, fontWeight: FontWeight.w600),
        ),
      ],
    ),
  );
}

class ProfilePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Profile', style: TextStyle(fontFamily: "Poppins", fontWeight: FontWeight.bold)),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            CircleAvatar(
              radius: 80,
              backgroundImage: AssetImage('assets/user_image.jpg'), // Replace 'assets/user_image.jpg' with the path to your user image
            ),
            SizedBox(height: 20),
            Text(
              'John Doe', // Replace 'John Doe' with the user's name
              style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
            ),
            SizedBox(height: 10),
            Text(
              'johndoe@example.com', // Replace 'johndoe@example.com' with the user's email
              style: TextStyle(fontSize: 18),
            ),
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: () {
                // Add functionality for editing profile
              },
              style: ButtonStyle(
                backgroundColor: MaterialStateProperty.all<Color>(Colors.blue),
              ),
              child: Text('Edit Profile', style: TextStyle(color: Colors.white),),
            ),
          ],
        ),
      ),
    );
  }
}

class ARChatPage extends StatefulWidget {
  @override
  _ARChatPageState createState() => _ARChatPageState();
}

class _ARChatPageState extends State<ARChatPage> {
  TextEditingController _messageController = TextEditingController();
  bool _isRecording = false;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('AR Chat', style: TextStyle(fontFamily: "Poppins", fontWeight: FontWeight.bold)),
      ),
      body: Column(
        children: [
          Expanded(
            child: ListView(
              padding: EdgeInsets.all(16.0),
              reverse: true,
              children: [
                // Example of a received message
                _buildMessageBubble('Hello!', isSentByMe: false),
                // Example of a sent message
                _buildMessageBubble('Hi there!', isSentByMe: true),
              ],
            ),
          ),
          Divider(height: 0.0),
          Container(
            padding: EdgeInsets.symmetric(horizontal: 8.0),
            child: Row(
              children: [
                Expanded(
                  child: TextField(
                    controller: _messageController,
                    decoration: InputDecoration.collapsed(
                      hintText: 'Type your message...',
                    ),
                  ),
                ),
                IconButton(
                  icon: Icon(Icons.mic),
                  onPressed: () {
                    setState(() {
                      _isRecording = !_isRecording;
                    });
                    // Implement voice recording functionality
                  },
                ),
                IconButton(
                  icon: Icon(Icons.send),
                  onPressed: () {
                    _sendMessage();
                  },
                ),
              ],
            ),
          ),
          if (_isRecording) Text('Recording...'), // Display a text widget indicating recording status
        ],
      ),
    );
  }

  Widget _buildMessageBubble(String message, {required bool isSentByMe}) {
    return Container(
      margin: EdgeInsets.symmetric(vertical: 8.0),
      alignment: isSentByMe ? Alignment.centerRight : Alignment.centerLeft,
      child: Container(
        padding: EdgeInsets.symmetric(horizontal: 16.0, vertical: 10.0),
        decoration: BoxDecoration(
          color: isSentByMe ? Colors.blue : Colors.grey[300],
          borderRadius: BorderRadius.circular(20.0),
        ),
        child: Text(
          message,
          style: TextStyle(color: isSentByMe ? Colors.white : Colors.black),
        ),
      ),
    );
  }

  void _sendMessage() {
    String message = _messageController.text.trim();
    if (message.isNotEmpty) {
      // Send message functionality
      setState(() {
        _messageController.clear();
      });
    }
  }
}

class SettingsPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Settings', style: TextStyle(fontFamily: "Poppins", fontWeight: FontWeight.bold)),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            ElevatedButton(
              onPressed: () {
                // Navigate to FAQ page
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => FAQPage()),
                );
              },
              style: ButtonStyle(
                backgroundColor: MaterialStateProperty.all<Color>(Colors.blue),
              ),
              child: Text('FAQ', style: TextStyle(fontFamily: "Poppins", color: Colors.white),),
            ),
            SizedBox(height: 16),
            ElevatedButton(
              onPressed: () {
                // Navigate to FAQ page
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => FirstScreen()),
                );
              },
              style: ButtonStyle(
                backgroundColor: MaterialStateProperty.all<Color>(Colors.blue),
              ),
              child: Text('Sign Out', style: TextStyle(fontFamily: "Poppins", color: Colors.white)),
            ),
          ],
        ),
      ),
    );
  }
}

class FAQPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('FAQ'),
      ),
      body: Center(
        child: Text('FAQ content goes here'),
      ),
    );
  }
}