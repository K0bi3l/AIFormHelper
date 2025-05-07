import React, { useState } from "react";
import "./Chat.css";

const Chat = () => {
    const [messages, setMessages] = useState([
        { text: "Hi! How can I help you?", sender: "bot" },
    ]);
    const [input, setInput] = useState("");

    const handleSend = () => {
        if (!input.trim()) return;

        const newMessage = { text: input, sender: "user" };
        setMessages((prev) => [...prev, newMessage]);
        
        setTimeout(() => {
            setMessages((prev) => [
                ...prev,
                { text: "hardcoded bot answear", sender: "bot" },
            ]);
        }, 1000);

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
