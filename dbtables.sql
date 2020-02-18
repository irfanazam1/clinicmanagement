CREATE DATABASE "Clinic"
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_United States.1252'
    LC_CTYPE = 'English_United States.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

-- SEQUENCE: public.department_id_seq

-- DROP SEQUENCE public.department_id_seq;

CREATE SEQUENCE public.department_id_seq
    INCREMENT 1
    START 3
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;

ALTER SEQUENCE public.department_id_seq
    OWNER TO postgres;

-- SEQUENCE: public.doctor_id_seq

-- DROP SEQUENCE public.doctor_id_seq;

CREATE SEQUENCE public.doctor_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;

ALTER SEQUENCE public.doctor_id_seq
    OWNER TO postgres;

-- SEQUENCE: public.patient_id_seq

-- DROP SEQUENCE public.patient_id_seq;

CREATE SEQUENCE public.patient_id_seq
    INCREMENT 1
    START 5
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;

ALTER SEQUENCE public.patient_id_seq
    OWNER TO postgres;

-- SEQUENCE: public.patient_visit_id_seq

-- DROP SEQUENCE public.patient_visit_id_seq;

CREATE SEQUENCE public.patient_visit_id_seq
    INCREMENT 1
    START 2
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;

ALTER SEQUENCE public.patient_visit_id_seq
    OWNER TO postgres;

-- Table: public.department

-- DROP TABLE public.department;

CREATE TABLE public.department
(
    id integer NOT NULL DEFAULT nextval('department_id_seq'::regclass),
    name character varying(50) COLLATE pg_catalog."default" NOT NULL,
    description text COLLATE pg_catalog."default"
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.department
    OWNER to postgres;

-- Table: public.doctor

-- DROP TABLE public.doctor;

CREATE TABLE public.doctor
(
    id integer NOT NULL DEFAULT nextval('doctor_id_seq'::regclass),
    doctor_id character varying(10) COLLATE pg_catalog."default" NOT NULL,
    name character varying(50) COLLATE pg_catalog."default" NOT NULL,
    address character varying(512) COLLATE pg_catalog."default",
    qualification character varying(100) COLLATE pg_catalog."default",
    specialization character varying(100) COLLATE pg_catalog."default",
    phone character varying(100) COLLATE pg_catalog."default",
    department_id integer NOT NULL,
    schedule character varying(512) COLLATE pg_catalog."default",
    gender character varying(6) COLLATE pg_catalog."default" NOT NULL,
    email character varying(256) COLLATE pg_catalog."default"
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.doctor
    OWNER to postgres;

-- Table: public.patient

-- DROP TABLE public.patient;

CREATE TABLE public.patient
(
    id integer NOT NULL DEFAULT nextval('patient_id_seq'::regclass),
    pat_id character varying(50) COLLATE pg_catalog."default" NOT NULL,
    name character varying(50) COLLATE pg_catalog."default" NOT NULL,
    dob date NOT NULL,
    gender character varying(10) COLLATE pg_catalog."default" NOT NULL,
    phone character varying(15) COLLATE pg_catalog."default",
    address character varying(512) COLLATE pg_catalog."default",
    email character varying(50) COLLATE pg_catalog."default",
    nic text COLLATE pg_catalog."default"
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.patient
    OWNER to postgres;

-- Table: public.patient_visit

-- DROP TABLE public.patient_visit;

CREATE TABLE public.patient_visit
(
    id integer NOT NULL DEFAULT nextval('patient_visit_id_seq'::regclass),
    visit_ref_number character varying(30) COLLATE pg_catalog."default" NOT NULL,
    patient_id integer NOT NULL,
    doctor_id integer NOT NULL,
    visit_date timestamp without time zone NOT NULL,
    visit_notes text COLLATE pg_catalog."default",
    followup bit(1) NOT NULL,
    followup_date timestamp without time zone,
    followup_reason text COLLATE pg_catalog."default",
    visit_cost numeric
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.patient_visit
    OWNER to postgres;