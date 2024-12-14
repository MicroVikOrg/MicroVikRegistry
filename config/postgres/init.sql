CREATE DATABASE microvikregistry;

\c microvikregistry;

CREATE TABLE IF NOT EXISTS nodes(
	id UUID PRIMARY KEY,
	url VARCHAR(150) NOT NULL UNIQUE,
	location VARCHAR(100),
	is_offical BOOLEAN,
	started_at TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
	wallet TEXT
);