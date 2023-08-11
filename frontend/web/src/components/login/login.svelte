<script lang="ts">
	import { api } from '../../api/api';
	import { onMount } from 'svelte';
	import type { User } from '../../api/client';
	import Field from './field.svelte';
	import { createForm } from 'svelte-forms-lib';
	import * as yup from 'yup';

	export let onUserCreated: () => void;

	async function createUser(username: string, password: string) {
		await api.user.createUser({
			username: username,
			password: password
		});
		onUserCreated();
	}

	const { form, errors, state, handleChange, handleSubmit } = createForm({
		initialValues: {
			name: '',
			password: ''
		},
		validationSchema: yup.object().shape({
			name: yup.string().required(),
			password: yup.string().required()
		}),
		onSubmit: (values) => {
			createUser(values.name, values.password);
		}
	});
</script>

<div>
	<form class="m-8 space-y-4 card p-4" on:submit={handleSubmit}>
		<label class="label">
			<span>Name</span>
			<input
				id="name"
				name="name"
				on:change={handleChange}
				on:blur={handleChange}
				bind:value={$form.name}
				class={'input'}
				type="text"
				placeholder="name"
			/>
			{#if $errors.name}
				<small>{$errors.name}</small>
			{/if}
		</label>
		<label class="label">
			<span>Password</span>
			<input
				id="password"
				name="password"
				on:change={handleChange}
				on:blur={handleChange}
				bind:value={$form.password}
				class={'input'}
				type="text"
				placeholder="password"
			/>
			{#if $errors.password}
				<small>{$errors.password}</small>
			{/if}
		</label>
		<button class="btn" type="submit">Submit</button>
	</form>
</div>
