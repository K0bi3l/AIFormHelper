import React, { useState } from "react";
import axios from "axios";
import "./Chat.css";

const Chat = ({formData, setFormData }) => {
    const [messages, setMessages] = useState([
        { text: "Hi! How can I help you?", sender: "bot" },
    ]);
    const [input, setInput] = useState("");

    const handleSend = async ()  => {
        if (!input.trim()) return;

        const newMessage = { text: input, sender: "user" };
        setMessages((prev) => [...prev, newMessage]);
                
        const request = {
            form: {
                firstname: formData.firstname,
                lastname: formData.lastname,
                email: formData.email,
                reasonOfContact: formData.reason, 
                urgency: formData.urgency
            },
            content: input
        };
        try {
            const response = await axios.post("https://localhost:7229/chat", request, {
                headers: {
                    "Content-Type": "application/json",
                }
            });



            setFormData({
                firstname: response.data.form.firstname,
                lastname: response.data.form.lastname,
                email: response.data.form.email,
                reasonOfContact: response.data.form.reasonOfContact,
                urgency: response.data.form.urgency
            });
            setMessages((prev) => [
                ...prev,
                { text: response.data.content, sender: "bot" },
            ]);
        } catch (error) {
            console.error("Error sending message:", error);
            setMessages((prev) => [
                ...prev,
                { text: "Sorry, something went wrong.", sender: "bot" },
            ]);
        }
        setInput("");
    };

    return (
        <div className="chat-container">
            <h2>Live Chat</h2>
            <div className="chat-box">
                {messages.map((msg) => (
                    <div                        
                        className={`chat-message ${msg.sender === "user" ? "user" : "bot"}`}
                    >
                        {msg.text}
                    </div>
                ))}
            </div>
            <div className="chat-input">
                <input
                    type="text"
                    placeholder="Napisz wiadomość..."
                    value={input}
                    onChange={(e) => setInput(e.target.value)}
                    onKeyDown={(e) => e.key === "Enter" && handleSend()}
                />
                <button onClick={handleSend}>Wyślij</button>
            </div>
        </div>
    );
};

export default Chat;
