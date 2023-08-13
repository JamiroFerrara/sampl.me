<script lang="ts">
	import { api } from '../../api/api';
	import { onMount } from 'svelte';
	import type { User } from '../../api/client';
	import Field from './field.svelte';
	import { createForm } from 'svelte-forms-lib';
	import * as yup from 'yup';
	import Icon from '../icon/icon.svelte';

	export let onUserCreated: () => void;

	async function createUser(username: string, email: string, password: string) {
		await api.user.createUser({
			username: username,
			email: email,
			password: password
		});
		onUserCreated();
	}

	const { form, errors, state, handleChange, handleSubmit } = createForm({
		initialValues: {
			username: '',
			email: '',
			password: ''
		},
		validationSchema: yup.object().shape({
			username: yup.string().required(),
			email: yup.string().required(),
			password: yup.string().required()
		}),
		onSubmit: (values) => {
			createUser(values.username, values.email, values.password);
		}
	});
</script>

<div class="border h-full flex justify-center">
	<form
		class="m-24 w-9/12 space-y-4 card p-8 flex flex-col justify-center"
		on:submit={handleSubmit}
	>
		<div class="w-full flex flex-col justify-center">
			<Icon />
			<h1 class="self-center font-bold text-3xl">Create a new account</h1>
		</div>
		<Field name="username" value={$form.username} error={$errors.password} {handleChange} />
		<Field name="email" value={$form.email} error={$errors.email} {handleChange} />
		<Field name="password" value={$form.password} error={$errors.password} {handleChange} />

		<div class="flex flex-row justify-center space-x-4">
			<button class="btn variant-filled" type="submit">Cancel</button>
			<button class="btn variant-filled-primary" type="submit">Login</button>
		</div>
		<a href="/login" class="self-center hover:text-primary-500 transform transition cursor-pointer">
			Already have an account?
		</a>
	</form>
</div>
